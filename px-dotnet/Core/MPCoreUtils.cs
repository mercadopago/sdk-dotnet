using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    public static class MPCoreUtils
    {
        #region Core Methods
        /// <summary>
        /// Find specified tokens.
        /// </summary>
        /// <param name="containerToken">Token container.</param>
        /// <param name="name">Name of the token we are searching.</param>
        /// <returns>List of tokens that match with the search parameter.</returns>
        public static List<JToken> FindTokens(this JToken containerToken, string name)
        {
            List<JToken> matches = new List<JToken>();
            FindTokens(containerToken, name, matches);
            return matches;
        }

        /// <summary>
        /// Core implementation of FindTokens
        /// </summary>
        /// <param name="containerToken">Token container.</param>
        /// <param name="name">Name of the token we are searching.</param>
        /// <param name="matches">List of tokens that match with the search parameter.</param>
        private static void FindTokens(JToken containerToken, string name, List<JToken> matches)
        {
            if (containerToken.Type == JTokenType.Object)
            {
                foreach (JProperty child in containerToken.Children<JProperty>())
                {
                    if (child.Name == name)
                    {
                        matches.Add(child.Value);
                    }

                    FindTokens(child.Value, name, matches);
                }
            }
            else if (containerToken.Type == JTokenType.Array)
            {
                foreach (JToken child in containerToken.Children())
                {
                    FindTokens(child, name, matches);
                }
            }
        }
        #endregion
    }
}
