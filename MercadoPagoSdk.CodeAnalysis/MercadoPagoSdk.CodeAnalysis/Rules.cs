using Microsoft.CodeAnalysis;

namespace MercadoPagoSdk.CodeAnalysis
{
    public static class Rules
    {
        private const string Category = "MercadoPagoSdk";

        public const string ApiPathParameterId = "MP001";
        public const string ApiPathParameterNotFoundId = "MP002";

        public static readonly DiagnosticDescriptor ApiPathParameter =
            new DiagnosticDescriptor(
                ApiPathParameterId,
                "API Path has a replaceable parameter placeholder",
                new LocalizableResourceString(nameof(Resources.ApiPathParameter), Resources.ResourceManager, typeof(Resources)),
                Category,
                DiagnosticSeverity.Error,
                isEnabledByDefault: true,
                description: "API path strings must use string interpolation to obtain parameter values from Resource instances.");

        public static readonly DiagnosticDescriptor ApiPathParameterNotFound =
            new DiagnosticDescriptor(
                ApiPathParameterNotFoundId,
                "API Path has an invalid replaceable parameter placeholder",
                new LocalizableResourceString(nameof(Resources.ApiPathParameterNotFound), Resources.ResourceManager, typeof(Resources)),
                Category,
                DiagnosticSeverity.Error,
                isEnabledByDefault: true,
                description: "API path strings must use string interpolation to obtain parameter values from Resource instances.");
    }
}