using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MercadoPagoSdk.CodeAnalysis
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ApiPathCodeFixProvider)), Shared]
    public class ApiPathCodeFixProvider : CodeFixProvider
    {
        private const string Title = "To String Interpolation";

        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(Rules.ApiPathParameterId);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            // TODO: Replace the following code with your own analysis, generating a CodeAction for each fix to suggest
            var diagnostic = context.Diagnostics.First();
            var diagnosticSpan = diagnostic.Location.SourceSpan;

            // Register a code action that will invoke the fix.
            context.RegisterCodeFix(
                CodeAction.Create(
                    Title,
                    c => ToStringInterpolationAsync(context.Document, root.FindToken(diagnosticSpan.Start).Parent, c),
                    equivalenceKey: Title),
                diagnostic);
        }

        private async Task<Document> ToStringInterpolationAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
        {
            if (!(node is LiteralExpressionSyntax stringLiteral))
                return document;

            var invocation = node.FindParent<InvocationExpressionSyntax>();

            if (invocation == null)
                return document;

            var semanticModel = await document.GetSemanticModelAsync(cancellationToken);

            var type = semanticModel.GetTypeInfo(invocation).Type;

            if (!type.IsResourceBase())
                return document;

            var name =
                invocation.Expression is MemberAccessExpressionSyntax maes
                    ? maes.Name as IdentifierNameSyntax
                    : invocation.Expression is IdentifierNameSyntax ins
                        ? ins
                        : null;

            if (name == null)
                return document;

            var validMethods =
                new[]
                {
                    "Get", "GetList", "Post", "Put", "Delete"
                };

            if (!validMethods.Contains(name.Identifier.Value))
                return document;

            var path = stringLiteral.Token.Value.ToString();

            if (!path.Contains(":"))
                return document;

            var parameters = Regex.Matches(path, ":[a-zA-Z0-9_-]*[^/]");

            if (parameters.Count == 0)
                return document;

            var syntaxList = new SyntaxList<InterpolatedStringContentSyntax>();

            var literalIndex = 0;

            foreach (Match parameter in parameters)
            {
                var snakeCaseName =
                    parameter.ToString()
                        .Replace(":", "");

                var propertyName = 
                    type.GetPropertyBySnakeCaseName(snakeCaseName)
                        ?.Name
                        ?? "[INVALID PROPERTY]";

                var literalPart = path.Substring(literalIndex, parameter.Index - literalIndex);

                if (literalPart.Length > 0)
                {
                    var token = SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.InterpolatedStringTextToken, literalPart, literalPart, SyntaxTriviaList.Empty);
                    syntaxList = syntaxList.Add(SyntaxFactory.InterpolatedStringText(token));
                }

                syntaxList = syntaxList.Add(SyntaxFactory.Interpolation(SyntaxFactory.IdentifierName(propertyName)));

                literalIndex = parameter.Index + parameter.Length;
            }
            
            if (literalIndex < path.Length)
            {
                var literalPart = path.Substring(literalIndex);
                var token = SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.InterpolatedStringTextToken, literalPart, literalPart, SyntaxTriviaList.Empty);
                syntaxList = syntaxList.Add(SyntaxFactory.InterpolatedStringText(token));
            }

            var newNode =
                SyntaxFactory.InterpolatedStringExpression(
                    SyntaxFactory.Token(SyntaxKind.InterpolatedStringStartToken), syntaxList);

            var root = await document.GetSyntaxRootAsync(cancellationToken);
            var newRoot = root.ReplaceNode(node, newNode);

            return document.WithSyntaxRoot(newRoot);
        }
    }
}