using MercadoPago;
using MercadoPago.Resources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture()]
    public class PreapprovalTest
    {
        Preapproval LastPreapproval;

        [SetUp]
        public void Init()
        {
            // Avoid SSL Cert error
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            SDK.CleanConfiguration();
            SDK.ClientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            SDK.ClientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
        }

        [Test]
        public void Preapproval_CreateShouldBeOk()
        {
            
            Preapproval preapproval = new Preapproval()
            {
                PayerEmail = "test@mail.com",
                BackUrl = "https://localhost.com",
                ExternalReference = "1",
                Reason = "TESTING 1",
                AutoRecurring = new MercadoPago.DataStructures.Preapproval.AutoRecurring()
                {
                    CurrencyId = MercadoPago.Common.CurrencyId.ARS,
                    Frequency = 1,
                    FrequencyType = MercadoPago.Common.FrequencyType.months,
                    TransactionAmount = 10,
                }
            };


            preapproval.Save();
            LastPreapproval = preapproval;

            Console.WriteLine("INIT POINT: " + preapproval.SandboxInitPoint);

            Assert.IsTrue(preapproval.Id.Length > 0 , "Failed: Preapproval could not be successfully created");
            Assert.IsTrue(preapproval.InitPoint.Length > 0, "Failed: Preapproval has not a valid init point");
        }

        [Test]
        public void Preapproval_FindByIDShouldbeOk()
        {
            Preapproval foundedPreapproval = Preapproval.FindById(LastPreapproval.Id); 
            Assert.AreEqual(foundedPreapproval.Id, LastPreapproval.Id); 
        }

        [Test]
        public void Preapproval_UpdateShouldBeOk()
        {
            LastPreapproval.ExternalReference = "DummyPreapproval for Integration Test";
            LastPreapproval.Update();
            Assert.AreEqual(LastPreapproval.ExternalReference, "DummyPreapproval for Integration Test"); 
        }  
    }
}
