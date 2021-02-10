using MercadoPago.DataStructures.Preapproval;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MercadoPago.Resources
{
    /// <summary>
    /// Preapproval methods.
    /// </summary>
    public class Preapproval : MPBase
    {
        #region Actions
        /// <summary>
        /// Find a preapproval trought an unique identifier
        /// </summary>
        /// <param name="id">Preapproval ID.</param>
        /// <returns>The preapproval.</returns>
        public static Preapproval FindById(string id)
        {
            return FindById(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Find a preapproval trought an unique identifier with Local Cache Flag.
        /// </summary>
        /// <param name="id">Preapproval ID.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The preapproval.</returns>
        [GETEndpoint("/preapproval/:id")]
        public static Preapproval FindById(string id, bool useCache, MPRequestOptions requestOptions)
        {
            return (Preapproval)ProcessMethod<Preapproval>(typeof(Preapproval), "FindById", id, useCache, requestOptions);
        }

        /// <summary>
        /// Save a new preapproval.
        /// </summary>
        /// <returns><c>true</c> if the preapproval was saved, otherwise <c>false</c>.</returns>
        public Boolean Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Save a new preapproval.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns><c>true</c> if the preapproval was saved, otherwise <c>false</c>.</returns>
        [POSTEndpoint("/preapproval")]
        public Boolean Save(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<Preapproval>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        ///  Update editable properties
        /// </summary>
        /// <returns><c>true</c> if the preapproval was updated, otherwise <c>false</c>.</returns>
        public Boolean Update()
        {
            return Update(null);
        }

        /// <summary>
        ///  Update editable properties
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns><c>true</c> if the preapproval was updated, otherwise <c>false</c>.</returns>
        [PUTEndpoint("/preapproval/:id")]
        public Boolean Update(MPRequestOptions requestOptions)
        {
            return ProcessMethodBool<Preapproval>("Update", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Searches the preapprovals acoording to specific filters.
        /// </summary>
        /// <param name="filters">Search filters.</param>
        /// <returns>A list of preapprovals.</returns>
        public static List<Preapproval> Search(Dictionary<string, string> filters)
        {
            return Search(filters, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Searches the preapprovals acoording to specific filters.
        /// </summary>
        /// <param name="filters">Search filters.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>A list of preapprovals.</returns>
        [GETEndpoint("/preapproval/search")]
        public static List<Preapproval> Search(Dictionary<string, string> filters, bool useCache, MPRequestOptions requestOptions)
        {
            return (List<Preapproval>)ProcessMethodBulk<Preapproval>(typeof(Preapproval), "Search", filters, useCache, requestOptions);
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
