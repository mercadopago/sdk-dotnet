using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct BackUrls
    {
        ///<summary>Approved payment URL</summary>
        [StringLength(600)]
        public string Success { get; set; }

        ///<summary>Pending payment URLL</summary>
        [StringLength(600)]
        public string Pending { get; set; }

        ///<summary>Canceled payment URL</summary>
        [StringLength(600)]
        public string Failure { get; set; }
    }
}
