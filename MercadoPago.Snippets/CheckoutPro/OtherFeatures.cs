using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MercadoPago.Client.Preference;
using MercadoPago.Config;

namespace MercadoPago.Snippets.CheckoutPro
{
    public static class OtherFeatures
    {
        public static async Task Create()
        {
            MercadoPagoConfig.PlatformId = "PLATFORM_ID";
            MercadoPagoConfig.IntegratorId = "INTEGRATOR_ID";
            MercadoPagoConfig.CorporationId = "CORPORATION_ID";

            var request = new PreferenceRequest();

            var paymentMethods = new PreferencePaymentMethodsRequest();
            paymentMethods.ExcludedPaymentMethods = new List<PreferencePaymentMethodRequest>();
            paymentMethods.ExcludedPaymentMethods.Add(new PreferencePaymentMethodRequest
            {
                Id = "master"
            });
            paymentMethods.ExcludedPaymentTypes = new List<PreferencePaymentTypeRequest>();
            paymentMethods.ExcludedPaymentTypes.Add(new PreferencePaymentTypeRequest
            {
                Id = "ticket"
            });
            paymentMethods.Installments = 12;
            request.PaymentMethods = paymentMethods;

            request.Items = new List<PreferenceItemRequest>
            {
                new PreferenceItemRequest
                {
                    Title = "Mi producto",
                    Quantity = 1,
                    CurrencyId = "BRL",
                    UnitPrice = 75.56m,
                },
                new PreferenceItemRequest
                {
                    Title = "Mi producto 2",
                    Quantity = 2,
                    CurrencyId = "BRL",
                    UnitPrice = 96.56m,
                },
            };

            var tracks = new List<PreferenceTrackRequest>();
            tracks.Add(new PreferenceTrackRequest
            {
                Type = "facebook_ad",
                Values = new PreferenceTrackValuesRequest
                {
                    PixelId = "PIXELID",
                }
            });
            tracks.Add(new PreferenceTrackRequest
            {
                Type = "google_ad",
                Values = new PreferenceTrackValuesRequest
                {
                    ConversionId = "CONVERSIONID",
                    ConversionLabel = "CONVERSIONLABEL",
                }
            });
            request.Tracks = tracks;

            var client = new PreferenceClient();
            var preference = await client.CreateAsync(request);

            Console.WriteLine($"Preference ID: {preference.Id}");
        }
    }
}
