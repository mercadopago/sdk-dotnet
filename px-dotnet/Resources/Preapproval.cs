using MercadoPago.DataStructures.Preapproval;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercadoPago.Resources
{
    public class Preapproval : MPBase
    {
        #region Actions
        /// <summary>
        /// Find a preapproval trought an unique identifier
        /// </summary>
        public static Preapproval FindById(string id)
        {
            return FindById(id, WITHOUT_CACHE);
        }
        /// <summary>
        /// Find a preapproval trought an unique identifier with Local Cache Flag
        /// </summary>
        [GETEndpoint("/preapproval/:id")]
        public static Preapproval FindById(string id, bool useCache)
        {
            return (Preapproval)ProcessMethod<Preapproval>(typeof(Preapproval), "FindById", id, useCache);
        }
        /// <summary>
        /// Save a new preapproval
        /// </summary>
        [POSTEndpoint("/preapproval")]
        public Boolean Save()
        {
            return ProcessMethodBool<Preapproval>("Save", WITHOUT_CACHE);
        }
        /// <summary>
        ///  Update editable properties
        /// </summary>
        [PUTEndpoint("/preapproval/:id")]
        public Boolean Update()
        {
            return ProcessMethodBool<Preapproval>("Update", WITHOUT_CACHE);
        }

        /// <summary>
        /// Get all preapprovals acoording to specific filters
        /// </summary>
        [GETEndpoint("/preapproval/search")]
        public static List<Preapproval> Search(Dictionary<string, string> filters)
        {
            return Search(filters, WITHOUT_CACHE);
        }
        /// <summary>
        /// Get all preapprovals acoording to specific filters
        /// </summary>
        [GETEndpoint("/preapproval/search")]
        public static List<Preapproval> Search(Dictionary<string, string> filters, bool useCache)
        {
            return (List<Preapproval>)ProcessMethodBulk<Preapproval>(typeof(Preapproval), "Search", filters, useCache);
        }
        #endregion


        #region Properties

        [StringLength(256)]
        private string _payer_email;
        [StringLength(500)]
        private string _back_url;
        private string _id;
        private string _init_point;
        private string _sandbox_init_point;
        [StringLength(256)]
        private string _external_reference;
        private string _reason;
        private AutoRecurring? _auto_recurring;

        #endregion

        #region Accesors

        /// <summary>
        ///  identifier
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        /// <summary>
        ///  Buy reason
        /// </summary>
        public string Reason
        {
            get
            {
                return _reason;
            }

            set
            {
                _reason = value;
            }
        }

        /// <summary>
        ///  Payer Email
        /// </summary>
        public string PayerEmail
        {
            get
            {
                return _payer_email;
            }

            set
            {
                _payer_email = value;
            }
        }

        /// <summary>
        ///  Return  URL
        /// </summary>
        public string BackUrl
        {
            get
            {
                return _back_url;
            }

            set
            {
                _back_url = value;
            }
        }
        /// <summary>
        /// Checkout access URL
        /// </summary>
        public string InitPoint
        {
            get
            {
                return _init_point;
            }

            private set
            {
                _init_point = value;
            }
        }
        /// <summary>
        /// Sandbox checkout access URL
        /// </summary>
        public string SandboxInitPoint
        {
            get
            {
                return _sandbox_init_point;
            }

            set
            {
                _sandbox_init_point = value;
            }
        }
        /// <summary>
        /// Auro Recurring Information
        /// </summary>
        public AutoRecurring? AutoRecurring
        {
            get
            {
                return _auto_recurring;
            }

            set
            {
                _auto_recurring = value;
            }
        }
        /// <summary>
        /// Reference you can synchronize with your payment system
        /// </summary>
        public string ExternalReference
        {
            get
            {
                return _external_reference;
            }

            set
            {
                _external_reference = value;
            }
        }

        #endregion



    }
}
