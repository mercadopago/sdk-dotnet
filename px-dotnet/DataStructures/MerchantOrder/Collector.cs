using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.MerchantOrder
{
    /// <summary>
    /// Collector information.
    /// </summary>
    public struct Collector
    {
        #region Properties

        private string id;
        private string email;
        private string nickName;

        #endregion

        #region Accessors

        /// <summary>
        /// Collector ID.
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Nickname.
        /// </summary>
        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }

        #endregion
    }
}
