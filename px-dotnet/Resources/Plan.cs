using System;
using MercadoPago.Common;
using MercadoPago.DataStructures.Plan;

namespace MercadoPago.Resources
{
    public class Plan : MPBase
    {
        #region Actions

        [GETEndpoint("/v1/plans/:id")]
        public static Plan Load(string id, bool useCache)
        {
            return (Plan)ProcessMethod<Plan>(typeof(Plan), "Load", id, useCache);
        }

        [POSTEndpoint("/v1/plans")]
        public Plan Save()
        {
            return (Plan)ProcessMethod<Plan>("Save", WITHOUT_CACHE);
        }

        [PUTEndpoint("/v1/plans/:id")]
        public Plan Update()
        {
            return (Plan)ProcessMethod<Plan>("Update", WITHOUT_CACHE);
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

        public string Id { get => id; set => id = value; }
        public float Application_fee { get => application_fee; set => application_fee = value; }
        public string Status { get => status; set => status = value; }
        public string Description { get => description; set => description = value; }
        public string External_reference { get => external_reference; set => external_reference = value; }
        public DateTime? Date_created { get => date_created;}
        public DateTime? Last_modified { get => last_modified;}
        public AutoRecurring Auto_recurring { get => auto_recurring; set => auto_recurring = value; }
        public bool Live_mode { get => live_mode; }
        public float Setup_fee { get => setup_fee; set => setup_fee = value; }
        public string Metadata { get => metadata; set => metadata = value; }

        #endregion
    }
}
