#!/usr/bin/env python3
"""Compare the COF regression tests before and after the nullable boolean fix.

Requires Python 3, Git, and a .NET 10 SDK with the runtimes selected by
--frameworks. No API credentials are needed and no payments are created.
"""

import argparse
import hashlib
import io
import json
import os
from pathlib import Path
import shutil
import subprocess
import sys
import tarfile
import tempfile
import xml.etree.ElementTree as ET


MODEL = Path("src/MercadoPago/Client/Payment/PaymentTransactionDataRequest.cs")
TESTS = Path("src/MercadoPago.Tests/Client/Payment/PaymentSerializationTest.cs")
PROJECT = "src/MercadoPago.Tests/MercadoPago.Tests.csproj"
METHODS = {
    "Serialize_CredentialOnFile_OmitsFirstTimeUse": 2,
    "Serialize_Subscriptions_OmitsFirstTransaction": 2,
    "Serialize_TransactionData_OmitsUnsetBooleans": 1,
}
FILTER = "|".join("FullyQualifiedName~" + name for name in METHODS)
NS = {"trx": "http://microsoft.com/schemas/VisualStudio/TeamTest/2010"}


def snapshot(root, commit, destination):
    archive = subprocess.check_output(
        ["git", "archive", commit, "src", "netfx.props", "global.json"], cwd=root
    )
    destination.mkdir()
    with tarfile.open(fileobj=io.BytesIO(archive)) as files:
        # Only repository source files are extracted; reject paths outside the snapshot.
        for member in files.getmembers():
            target = (destination / member.name).resolve()
            if destination.resolve() not in target.parents or member.issym() or member.islnk():
                raise RuntimeError("Unsafe archive entry: " + member.name)
        files.extractall(destination)


def inspect_results(path, expected):
    if not path.is_file():
        raise RuntimeError("Missing TRX report; check the build/restore log: " + str(path))
    document = ET.parse(path)
    cases = []
    counts = dict.fromkeys(METHODS, 0)
    for result in document.findall(".//trx:UnitTestResult", NS):
        name = result.attrib["testName"]
        method = name.split("(", 1)[0].rsplit(".", 1)[-1]
        if method not in counts:
            raise RuntimeError("Unexpected test: " + name)
        counts[method] += 1
        outcome = result.attrib["outcome"]
        message = result.findtext("trx:Output/trx:ErrorInfo/trx:Message", default="", namespaces=NS)
        cases.append({"name": name, "outcome": outcome, "message": message})
        if outcome != expected:
            raise RuntimeError("Unexpected outcome for " + name + ": " + outcome)
        if expected == "Failed" and "Assert.False() Failure" not in message:
            raise RuntimeError("Baseline failed for a different reason: " + name + "\n" + message)
    if counts != METHODS:
        raise RuntimeError("Expected all five regression cases, found " + repr(counts))
    return cases


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--baseline-ref", default="master", help="Git ref for the original SDK (default: master; also supports 3.7.0)")
    parser.add_argument("--dotnet", default="dotnet", help="Path to the dotnet executable")
    parser.add_argument("--frameworks", nargs="+", choices=["net8.0", "net10.0"], default=["net8.0", "net10.0"])
    parser.add_argument("--output", type=Path, help="Directory for logs, TRX, and summary.json; must be new or empty")
    args = parser.parse_args()
    root = Path(__file__).resolve().parents[1]
    dotnet = shutil.which(args.dotnet)
    if dotnet is None:
        parser.error("dotnet was not found; use --dotnet /path/to/dotnet")
    commit = subprocess.check_output(
        ["git", "rev-parse", "--verify", args.baseline_ref + "^{commit}"], cwd=root, text=True
    ).strip()
    output = args.output.resolve() if args.output else Path(tempfile.mkdtemp(prefix="cof-comparison-results-"))
    if output.exists() and any(output.iterdir()):
        parser.error("--output must be a new or empty directory")
    output.mkdir(parents=True, exist_ok=True)
    print("Baseline: " + args.baseline_ref + " (" + commit + ")", flush=True)
    print("Reports: " + str(output), flush=True)
    print("The fixed snapshot uses the working tree model and the same regression tests.", flush=True)
    summary = {"baseline_ref": args.baseline_ref, "baseline_commit": commit, "frameworks": {}, "validation": "serialization only; no API calls"}
    with tempfile.TemporaryDirectory(prefix="cof-comparison-source-") as temporary:
        work = Path(temporary)
        baseline = work / "baseline"
        fixed = work / "fixed"
        snapshot(root, commit, baseline)
        shutil.copy2(root / TESTS, baseline / TESTS)
        shutil.copytree(baseline, fixed)
        shutil.copy2(root / MODEL, fixed / MODEL)
        for label, source in [("baseline", baseline), ("fixed", fixed)]:
            summary[label + "_model_sha256"] = hashlib.sha256((source / MODEL).read_bytes()).hexdigest()
        if summary["baseline_model_sha256"] == summary["fixed_model_sha256"]:
            raise RuntimeError("The baseline and fixed models are identical; choose a ref before the fix.")
        environment = os.environ.copy()
        environment.setdefault("DOTNET_CLI_HOME", str(work / "dotnet-home"))
        environment.setdefault("NUGET_PACKAGES", str(work / "nuget"))
        environment["DOTNET_CLI_TELEMETRY_OPTOUT"] = "1"
        environment["DOTNET_NOLOGO"] = "1"
        for framework in args.frameworks:
            summary["frameworks"][framework] = {}
            for label, source, expected, expected_exit in [
                ("baseline", baseline, "Failed", 1),
                ("fixed", fixed, "Passed", 0),
            ]:
                reports = output / framework / label
                reports.mkdir(parents=True)
                print("Running " + label + " on " + framework + "...", flush=True)
                command = [
                    dotnet, "test", PROJECT, "--configuration", "Release",
                    "--framework", framework, "--filter", FILTER,
                    "--logger", "trx;LogFileName=results.trx",
                    "--results-directory", str(reports), "--verbosity", "minimal",
                ]
                with (reports / "test.log").open("w") as log:
                    result = subprocess.run(command, cwd=source, env=environment, stdout=log, stderr=subprocess.STDOUT)
                if result.returncode != expected_exit:
                    raise RuntimeError("Unexpected exit code " + str(result.returncode) + "; inspect " + str(reports / "test.log"))
                cases = inspect_results(reports / "results.trx", expected)
                summary["frameworks"][framework][label] = cases
                print("  " + str(len(cases)) + " cases " + expected.lower() + " as expected.", flush=True)
    (output / "summary.json").write_text(json.dumps(summary, indent=2) + "\n")
    print("PASS: the original SDK adds unset booleans; the fix omits them and preserves explicit true/false.")
    print("This confirms the serialization defect and correction. API acceptance requires a separate sandbox test.")
    return 0


if __name__ == "__main__":
    try:
        sys.exit(main())
    except (OSError, RuntimeError, subprocess.CalledProcessError, ET.ParseError) as error:
        print("ERROR: " + str(error), file=sys.stderr)
        sys.exit(1)
