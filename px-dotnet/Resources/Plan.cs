using System;
using MercadoPago.DataStructures.Plan;

namespace MercadoPago.Resources
{
    public sealed class Plan : Resource<Plan>
    {
        #region Actions

        public static Plan Load(string id, bool useCache = false) => Get($"/v1/plans/{id}", useCache);

        public Plan Save() => Post("/v1/plans");

        public Plan Update() => Put($"/v1/plans/{Id}");

        #endregion

        #region Properties 

        public string Id { get; set; }

        public decimal Application_fee { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public string External_reference { get; set; }

        public DateTime? Date_created { get; set; }

        public DateTime? Last_modified { get; set; }

        public AutoRecurring Auto_recurring { get; set; }

        public bool Live_mode { get; set; }

        public decimal Setup_fee { get; set; }

        public string Metadata { get; set; }

        #endregion
    }
}