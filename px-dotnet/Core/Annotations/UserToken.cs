using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago
{
    /// <summary>
    /// Attribute to define a custom user token for a certain resource.
    /// </summary>
    public class UserToken : Attribute
    {
        /// <summary>
        /// Custom token to use in the resource.
        /// </summary>
        private string UserAsignedToken { get; set; }

        /// <summary>
        /// Basic constructor for attribute.
        /// </summary>
        /// <param name="token"></param>
        public UserToken(string token)
        {
            this.UserAsignedToken = token;
        }

        /// <summary>
        /// Getter for attribute.
        /// </summary>
        /// <returns>User asigned token.</returns>
        public string GetUserToken()
        {
            return this.UserAsignedToken;
        }
    }
}
