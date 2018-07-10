using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MercadoPago.DataStructures.Preapproval;

namespace MercadoPago.Resources
{
    public sealed class Preapproval : Resource<Preapproval>
    {
        #region Actions

        /// <summary>
        /// Get all preapprovals acoording to specific filters
        /// </summary>
        public static List<Preapproval> Search(Dictionary<string, string> filters, bool useCache = false) =>
            GetList("/preapproval/search", useCache, filters);

        public static IQueryable<Preapproval> Query(bool useCache = false) =>
            CreateQuery("/preapproval/search", useCache);

        /// <summary>
        /// Find a preapproval trought an unique identifier with Local Cache Flag
        /// </summary>
        public static Preapproval FindById(string id, bool useCache = false) => Get($"/preapproval/{id}", useCache);

        /// <summary>
        /// Save a new preapproval
        /// </summary>
        public Preapproval Save() => Post("/preapproval");

        /// <summary>
        ///  Update editable properties
        /// </summary>
        public Preapproval Update() => Put($"/preapproval/{Id}");

        #endregion

        #region Properties

        /// <summary>
        ///  identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///  Buy reason
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        ///  Payer Email
        /// </summary>
        [StringLength(256)]
        public string PayerEmail { get; set; }

        /// <summary>
        ///  Return  URL
        /// </summary>
        [StringLength(500)]
        public string BackUrl { get; set; }

        /// <summary>
        /// Checkout access URL
        /// </summary>
        public string InitPoint { get; private set; }

        /// <summary>
        /// Sandbox checkout access URL
        /// </summary>
        public string SandboxInitPoint { get; set; }

        /// <summary>
        /// Auro Recurring Information
        /// </summary>
        public AutoRecurring? AutoRecurring { get; set; }

        /// <summary>
        /// Reference you can synchronize with your payment system
        /// </summary>
        [StringLength(256)]
        public string ExternalReference { get; set; }

        #endregion
    }
}