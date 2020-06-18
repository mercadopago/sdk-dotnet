using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MercadoPago.DataStructures.Preference
{
    public struct BackUrls
    {
        #region Properties
        [StringLength(600)]
        private string _success; 
        [StringLength(600)]
        private string _pending; 
        [StringLength(600)]
        private string _failure; 
        #endregion

        #region Accessors 
        /// <summary>Approved payment URL</summary>
        public string Success 
        { 
            get { return  _success; } 
            set {  _success = value; } 
        }
        /// <summary>Pending payment URLL</summary>
        public string Pending 
        { 
            get { return  _pending; } 
            set {  _pending = value; } 
        }
        /// <summary>Canceled payment URL</summary>
        public string Failure 
        { 
            get { return  _failure; } 
            set {  _failure = value; } 
        } 
        #endregion

    }
}
