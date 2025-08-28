# Releases

## VERSION 2.9.0
- Order: set default `capture_mode = "automatic_async"` and update fields/tests.
- Examples: fix `examples/Order/Create.cs` example.
- Examples: improve `examples/Order/Get.cs` (env vars, boleto, additional_info).
- Chore: remove `.idea` project files.
- Refactor: standardize messages to English and align .NET target version.
- Fix: null-safety when building error message in `MercadoPagoApiException`.

## VERSION 2.4.0
- Require .NET Framework 6.0 as minimum version.
- Avoid rethrowing exception that changes stack trace information.
- Add pre-commit.
- Add CHANGELOG file.
