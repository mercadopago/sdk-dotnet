using System;
namespace MercadoPago.DataStructures.Preference
{
    public struct CategoryDescriptor
    {
        /// <summary>
        /// Category Descriptor Passenger
        /// </summary>
        public Passenger passenger { get; set; }

        /// <summary>
        /// Category Descriptor Route
        /// </summary>
        public Route route { get; set; }
    }
}
