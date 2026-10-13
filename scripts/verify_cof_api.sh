#!/usr/bin/env bash
# Compare published test-card flows against 3.7.0 and the working tree fix.
set -euo pipefail

task_root=$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)
task_dotnet=${DOTNET_BIN:-dotnet}
task_flow=${MP_PROBE_FLOW:-initial}
if [ "$task_flow" != initial ] && [ "$task_flow" != cof-direct ]; then
    printf 'MP_PROBE_FLOW must be initial or cof-direct.\n' >&2
    exit 2
fi
if ! command -v "$task_dotnet" >/dev/null 2>&1; then
    printf 'dotnet was not found. Set DOTNET_BIN to the SDK executable.\n' >&2
    exit 2
fi
if [ -z "${MP_TOKEN_BASE64:-${MLB_TOKEN:-}}" ]; then
    printf 'MP_TOKEN_BASE64 (or MLB_TOKEN) is missing; export the Base64-encoded test credential.\n' >&2
    exit 2
fi
task_source=$(mktemp -d "${TMPDIR:-/tmp}/cof-api-source.XXXXXX")
trap 'rm -rf "$task_source"' EXIT
mkdir -p "$task_root/artifacts"
task_reports=$(mktemp -d "$task_root/artifacts/cof-api.XXXXXX")
mkdir "$task_source/baseline"
git -C "$task_root" archive 3.7.0 src netfx.props global.json | tar -xf - -C "$task_source/baseline"
cp -R "$task_source/baseline" "$task_source/fixed"
cp "$task_root/src/MercadoPago/Client/Payment/PaymentTransactionDataRequest.cs" \
   "$task_source/fixed/src/MercadoPago/Client/Payment/PaymentTransactionDataRequest.cs"
for task_variant in baseline fixed; do
    mkdir -p "$task_source/$task_variant/scripts/CofApiProbe"
    cp "$task_root/scripts/CofApiProbe/Program.cs" "$task_root/scripts/CofApiProbe/CofApiProbe.csproj" \
       "$task_source/$task_variant/scripts/CofApiProbe/"
done
export DOTNET_CLI_TELEMETRY_OPTOUT=1 DOTNET_NOLOGO=1
export DOTNET_CLI_HOME=${DOTNET_CLI_HOME:-"$task_source/dotnet-home"}
export NUGET_PACKAGES=${NUGET_PACKAGES:-"$task_source/nuget"}
printf 'Reports: %s\n' "$task_reports"
git -C "$task_root" rev-parse '3.7.0^{commit}' > "$task_reports/baseline-commit.txt"

for task_variant in baseline fixed; do
    "$task_dotnet" build "$task_source/$task_variant/scripts/CofApiProbe/CofApiProbe.csproj" \
        --configuration Release --verbosity quiet > "$task_reports/$task_variant-build.log" 2>&1
done
task_fixed_dll="$task_source/fixed/scripts/CofApiProbe/bin/Release/net10.0/CofApiProbe.dll"
if ! "$task_dotnet" "$task_fixed_dll" preflight > "$task_reports/preflight.json"; then
    cat "$task_reports/preflight.json"
    printf 'Preflight failed. No payment comparison was attempted.\n' >&2
    exit 2
fi

if ! "$task_dotnet" "$task_fixed_dll" tokenize > "$task_reports/tokenization.json"; then
    cat "$task_reports/tokenization.json"
    printf 'Card tokenization failed. No payment comparison was attempted.\n' >&2
    exit 2
fi
cat "$task_reports/tokenization.json"

for task_variant in baseline fixed; do
    printf 'Running %s with the published %s test card...\n' "$task_variant" "${MP_TEST_SITE:-MLB}"
    task_status=0
    "$task_dotnet" "$task_source/$task_variant/scripts/CofApiProbe/bin/Release/net10.0/CofApiProbe.dll" \
        "$task_flow" > "$task_reports/$task_variant.json" || task_status=$?
    printf '%s\n' "$task_status" > "$task_reports/$task_variant-exit-code.txt"
    cat "$task_reports/$task_variant.json"
done

python3 - "$task_reports" <<'PY'
import json
import sys
from pathlib import Path

reports = Path(sys.argv[1])
baseline = json.loads((reports / 'baseline.json').read_text())
fixed = json.loads((reports / 'fixed.json').read_text())
stage = 'create_direct_cof_payment' if baseline['mode'] == 'cof-direct' else 'create_initial_cit'
before = [step for step in baseline['steps'] if step['stage'] == stage]
after = [step for step in fixed['steps'] if step['stage'] == stage]
reproduced = bool(before and before[0]['http_status'] == 400
                  and 'first_time_use' in json.dumps(before[0].get('api_message', '')))
corrected = bool(after and 200 <= after[0]['http_status'] < 300
                 and 'first_time_use' not in after[0]['point_of_interaction']['transaction_data']
                 and (fixed.get('initial_payment', fixed.get('created_payment', {})).get('live_mode') is False or fixed.get('test_user_tag') is True))
summary = {'baseline_bug_reproduced': reproduced, 'fixed_initial_request_accepted': corrected,
           'flow': baseline['mode'],
           'baseline_first_time_use_present': bool(before and 'first_time_use' in before[0]['point_of_interaction']['transaction_data']),
           'fixed_first_time_use_present': bool(after and 'first_time_use' in after[0]['point_of_interaction']['transaction_data']),
           'fixed_mit_attempted': 'subsequent_payment' in fixed,
           'scope': fixed.get('site_id', fixed.get('expected_site')) + ' test account; original and fixed PaymentClient.CreateAsync'}
(reports / 'comparison.json').write_text(json.dumps(summary, indent=2) + '\n')
print(json.dumps(summary, indent=2))
if not (reproduced and corrected):
    print('INCONCLUSIVE: inspect the stage and API error in the reports.', file=sys.stderr)
    sys.exit(1)
print('PASS: the original COF error was reproduced and the fixed CIT request was accepted.')
PY
