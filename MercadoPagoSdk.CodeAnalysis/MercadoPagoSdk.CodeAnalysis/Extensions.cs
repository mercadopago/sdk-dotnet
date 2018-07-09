using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MercadoPagoSdk.CodeAnalysis
{
    public static class Extensions
    {
        public static TParent FindParent<TParent>(this SyntaxNode node) where TParent: SyntaxNode
        {
            if (node == null)
                return null;

            if (node.Parent is TParent found)
                return found;

            return FindParent<TParent>(node.Parent);
        }

        public static ITypeSymbol GetTypeSymbol(this SyntaxNode node, SemanticModel semanticModel)
        {
            switch (node)
            {
                case ElementAccessExpressionSyntax eaes when eaes.Expression is IdentifierNameSyntax ins:
                    return semanticModel.GetTypeInfo(ins).Type;
                case ElementAccessExpressionSyntax eaes when eaes.Expression is MemberAccessExpressionSyntax maes:
                    return semanticModel.GetTypeInfo(maes.Name).Type;
                case InvocationExpressionSyntax ies when ies.Expression is MemberAccessExpressionSyntax maes:
                    return semanticModel.GetTypeInfo(maes.Expression).Type;
                case InvocationExpressionSyntax ies when ies.Expression is GenericNameSyntax gns:
                    return semanticModel.GetTypeInfo(gns.Parent).Type;
                default:
                    return null;
            }
        }

        public static bool IsResourceBase(this ITypeSymbol type)
        {
            var baseType = type;

            while (baseType != null && baseType.ToString() != "MercadoPago.ResourceBase")
                baseType = baseType.BaseType;

            return baseType != null;
        }

        public static IPropertySymbol GetPropertyBySnakeCaseName(this ITypeSymbol type, string snakeCaseName)
        {
            var property =
                type.GetMembers()
                    .OfType<IPropertySymbol>()
                    .FirstOrDefault(x => x.Name.ToSnakeCase() == snakeCaseName);
            return property;
        }

        public static string ToSnakeCase(this string text) =>
            Regex.Replace(text, @"(?<=[a-z0-9])[A-Z\s]", "_$0").ToLower();
    }
}