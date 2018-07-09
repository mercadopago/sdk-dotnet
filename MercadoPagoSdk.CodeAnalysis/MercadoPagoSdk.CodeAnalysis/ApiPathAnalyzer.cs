using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MercadoPagoSdk.CodeAnalysis
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ApiPathAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
            ImmutableArray.Create(Rules.ApiPathParameter, Rules.ApiPathParameterNotFound);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.StringLiteralExpression);
        }

        private void Analyze(SyntaxNodeAnalysisContext context)
        {
            if (!(context.Node is LiteralExpressionSyntax stringLiteral))
                return;

            var invocation = context.Node.FindParent<InvocationExpressionSyntax>();

            if (invocation == null)
                return;

            var type = context.SemanticModel.GetTypeInfo(invocation).Type;

            if (!type.IsResourceBase())
                return;

            var name =
                invocation.Expression is MemberAccessExpressionSyntax maes
                    ? maes.Name as IdentifierNameSyntax
                    : invocation.Expression is IdentifierNameSyntax ins
                        ? ins
                        : null;

            if (name == null)
                return;

            var validMethods =
                new[]
                {
                    "Get", "GetList", "Post", "Put", "Delete"
                };

            if (!validMethods.Contains(name.Identifier.Value))
                return;

            var path = stringLiteral.Token.Value.ToString();

            if (!path.Contains(":"))
                return;

            var parameters = Regex.Matches(path, ":[a-zA-Z0-9_-]*[^/]");

            if (parameters.Count == 0)
                return;

            foreach (var parameter in parameters)
            {
                var snakeCaseName = 
                    parameter.ToString()
                             .Replace(":", "");

                var property = type.GetPropertyBySnakeCaseName(snakeCaseName);

                if (property != null)
                {
                    var propertyName = $"{type.ContainingNamespace}.{type.Name}.{property.Name}";

                    var diagnostic = Diagnostic.Create(Rules.ApiPathParameter, context.Node.GetLocation(), snakeCaseName, propertyName);
                    context.ReportDiagnostic(diagnostic);
                }
                else
                {
                    var diagnostic = Diagnostic.Create(Rules.ApiPathParameterNotFound, context.Node.GetLocation(), snakeCaseName);
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
    }
}
