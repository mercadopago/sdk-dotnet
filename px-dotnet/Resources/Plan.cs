using System;
using MercadoPago.Common;
using MercadoPago.DataStructures.Plan;

namespace MercadoPago.Resources
{
    /// <summary>
    /// Access to Plan methods.
    /// </summary>
    public class Plan : MPBase
    {
        #region Actions

        /// <summary>
        /// Load a plan by your ID.
        /// </summary>
        /// <param name="id">Plan ID.</param>
        /// <returns>The plan.</returns>
        public static Plan Load(string id)
        {
            return Load(id, WITHOUT_CACHE, null);
        }

        /// <summary>
        /// Load a plan by your ID.
        /// </summary>
        /// <param name="id">Plan ID.</param>
        /// <param name="useCache">Use cache or not.</param>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The plan.</returns>
        [GETEndpoint("/v1/plans/:id")]
        public static Plan Load(string id, bool useCache, MPRequestOptions requestOptions)
        {
            return (Plan)ProcessMethod<Plan>(typeof(Plan), "Load", id, useCache, requestOptions);
        }

        /// <summary>
        /// Saves a new plan.
        /// </summary>
        /// <returns>The saved plan.</returns>
        public Plan Save()
        {
            return Save(null);
        }

        /// <summary>
        /// Saves a new plan.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The saved plan.</returns>
        [POSTEndpoint("/v1/plans")]
        public Plan Save(MPRequestOptions requestOptions)
        {
            return (Plan)ProcessMethod<Plan>("Save", WITHOUT_CACHE, requestOptions);
        }

        /// <summary>
        /// Updates plan editable properties.
        /// </summary>
        /// <returns>The updated plan.</returns>
        public Plan Update()
        {
            return Update(null);
        }

        /// <summary>
        /// Updates plan editable properties.
        /// </summary>
        /// <param name="requestOptions">Request options.</param>
        /// <returns>The updated plan.</returns>
        [PUTEndpoint("/v1/plans/:id")]
        public Plan Update(MPRequestOptions requestOptions)
        {
            return (Plan)ProcessMethod<Plan>("Update", WITHOUT_CACHE, requestOptions);
        }

        #endregion

        #region Properties 
        private string id;
        private float application_fee;
        private string status;
        private string description;
        private string external_reference;
        private DateTime? date_created;
        private DateTime? last_modified;
        private AutoRecurring auto_recurring;
        private Boolean live_mode;
        private float setup_fee;
        private string metadata; 
        #endregion


        #region Accessors 
        /// <summary>
        /// Plan ID.
        /// </summary>
        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Application fee.
        /// </summary>
        public float Application_fee
        {
            get
            {
                return application_fee;
            }

            set
            {
                application_fee = value;
            }
        }

        /// <summary>
        /// Status.
        /// </summary>
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        /// <summary>
        /// Description.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        /// <summary>
        /// External reference.
        /// </summary>
        public string External_reference
        {
            get
            {
                return external_reference;
            }

            set
            {
                external_reference = value;
            }
        }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime? Date_created
        {
            get
            {
                return date_created;
            }

            set
            {
                date_created = value;
            }
        }

        /// <summary>
        /// Last modified date.
        /// </summary>
        public DateTime? Last_modified
        {
            get
            {
                return last_modified;
            }

            set
            {
                last_modified = value;
            }
        }

        /// <summary>
        /// Auto recurring.
        /// </summary>
        public AutoRecurring Auto_recurring
        {
            get
            {
                return auto_recurring;
            }

            set
            {
                auto_recurring = value;
            }
        }

        /// <summary>
        /// Live mode.
        /// </summary>
        public bool Live_mode
        {
            get
            {
                return live_mode;
            }

            set
            {
                live_mode = value;
            }
        }

        /// <summary>
        /// Setup fee.
        /// </summary>
        public float Setup_fee
        {
            get
            {
                return setup_fee;
            }

            set
            {
                setup_fee = value;
            }
        }

        /// <summary>
        /// Metadata.
        /// </summary>
        public string Metadata
        {
            get
            {
                return metadata;
            }

            set
            {
                metadata = value;
            }
        }
        #endregion
    }
}
