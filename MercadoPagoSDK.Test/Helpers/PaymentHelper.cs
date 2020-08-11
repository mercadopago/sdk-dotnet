using System;
using System.Collections.Generic;
using MercadoPago.DataStructures.Payment;
using MercadoPago.Resources;
using Address = MercadoPago.DataStructures.Payment.Address;

namespace MercadoPagoSDK.Test.Helpers
{
    public static class PaymentHelper
    {
        public static Payment getPaymenData(string PublicKey, string Status)
        {
            var addInfPayerAdd = new Address
            {
                StreetName = "aaa",
                StreetNumber = 5,
                ZipCode = "54321"
            };

            var addInfPayerPhone = new Phone
            {
                AreaCode = "00",
                Number = "5512345678"
            };

            DateTime fechaReg = new DateTime(2000, 01, 31);

            var addInfoPayer = new AdditionalInfoPayer
            {
                FirstName = "Rubén",
                LastName = "González",
                RegistrationDate = fechaReg,
                Address = addInfPayerAdd,
                Phone = addInfPayerPhone
            };

            var item = new Item
            {
                Id = "producto123",
                Title = "Celular blanco",
                Description = "4G, 32 GB",
                Quantity = 1,
                PictureUrl = "http://www.imagenes.com/celular.jpg",
                UnitPrice = 100.4m
            };


            List<Item> items = new List<Item>();
            items.Add(item);

            ReceiverAddress receiverAddress = new ReceiverAddress
            {
                StreetName = "insurgentes sur",
                StreetNumber = 1,
                Zip_code = "12345"
            };

            Shipment shipment = new Shipment
            {
                ReceiverAddress = receiverAddress
            };

            var addInf = new AdditionalInfo
            {
                Payer = addInfoPayer,
                Shipments = shipment,
                Items = items

            };

            Payment payment = new Payment
            {
                TransactionAmount = (float)20.0,
                Token = CardHelper.SingleUseCardToken(PublicKey, Status), // 1 use card token
                Description = "Pago de Prueba",
                PaymentMethodId = "visa",
                ExternalReference = "INTEGRATION-TEST-PAYMENT",
                Installments = 1,
                Payer = new Payer
                {
                    Email = Environment.GetEnvironmentVariable("EMAIL")
                },
                AdditionalInfo = addInf
            };

            return payment;
        }
    }
}
