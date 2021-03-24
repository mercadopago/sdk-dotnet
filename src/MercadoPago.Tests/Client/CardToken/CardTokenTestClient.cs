namespace MercadoPago.Tests.Client.CardToken
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MercadoPago.Client;
    using MercadoPago.Resource.CardToken;
    using MercadoPago.Resource.User;
    using MercadoPago.Tests.Client.Helper;

    /// <summary>
    /// Class to create card token for tests.
    /// </summary>
    /// <remarks>
    /// You must not create a card token with card number on the back end of your application
    /// (only if you are PCI compliant).
    /// To create a card token, check
    /// <see cref="https://www.mercadopago.com/developers/en/guides/online-payments/checkout-api/introduction">here</see>.
    /// </remarks>
    public class CardTokenTestClient : MercadoPagoClient<CardToken>
    {
        private static readonly IDictionary<string, string> StatusCardholderName = new Dictionary<string, string>
        {
            ["approved"] = "APRO",
            ["pending"] = "CONT",
            ["rejected"] = "OTHE",
        };

        private static readonly IDictionary<string, string> SiteIdCard = new Dictionary<string, string>
        {
            ["MLA"] = "5031755734530604",
            ["MLB"] = "5031433215406351",
            ["MLM"] = "5474925432670366",
            ["MCO"] = "5254133674403564",
            ["MLC"] = "5416752602582580",
            ["MPE"] = "5118437884865678",
            ["MLU"] = "5808887774641586",
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CardTokenTestClient"/> class.
        /// </summary>
        public CardTokenTestClient()
            : base(null, null)
        {
        }

        /// <summary>
        /// Creates a test card token.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="paymentStatus">Desired payment status.</param>
        /// <returns>The test card token./returns>
        public Task<CardToken> CreateTestCardToken(User user, string paymentStatus)
        {
            var request = new CardTokenTestCreate
            {
                CardNumber = SiteIdCard[user.SiteId],
                SecurityCode = "123",
                ExpirationMonth = 11,
                ExpirationYear = DateTime.Now.AddYears(10).Year,
                Cardholder = new CardTokenCardholderTestCreate
                {
                    Name = StatusCardholderName[paymentStatus],
                    Identification = IdentificationHelper.GetIdentification(user),
                },
            };

            return SendAsync(
                "/v1/card_tokens",
                MercadoPago.Http.HttpMethod.POST,
                request);
        }
    }
}
