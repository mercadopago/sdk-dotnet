using System;
namespace MercadoPago.Client.Payment
{
    /// <summary>
    /// Data used to exchange 3DS authentication information verified by a third party.
    /// </summary>
    public class PaymentAuthenticationRequest
    {
        /// <summary>
        /// Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Cryptogram.
        /// </summary>
        public string Cryptogram { get; set; }

        /// <summary>
        /// 3DS Server Trans ID.
        /// </summary>
        public string ThreeDsServerTransId { get; set; }

        /// <summary>
        /// ECI.
        /// </summary>
        public string Eci { get; set; }

        /// <summary>
        /// 3DS Trans ID.
        /// </summary>
        public string DsTransId { get; set; }

        /// <summary>
        /// ACS Trans ID.
        /// </summary>
        public string AcsTransId { get; set; }

        /// <summary>
        /// 3DS Version.
        /// </summary>
        public string ThreeDsVersion { get; set; }

        /// <summary>
        /// Authentication Status.
        /// </summary>
        public string AuthenticationStatus { get; set; }
    }
}

