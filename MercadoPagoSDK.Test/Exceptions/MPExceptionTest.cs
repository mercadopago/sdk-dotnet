using System;
using MercadoPago;
using NUnit.Framework;

namespace MercadoPagoSDK.Test
{
	[TestFixture()]
	public class MPExceptionTest
	{
		[Test()]
		public void MPExceptionTestToStringOverride()
		{
			MPException exception = new MPException("Some Exception message");
			Assert.AreEqual("Mercadopago.Exceptions.MPException: Some Exception message", exception.ToString().Trim());

			MPException exception2 = new MPException("Some Exception message 2", new MPException("InnerExceptionMessage 2"));
			Assert.AreEqual("Mercadopago.Exceptions.MPException: InnerExceptionMessage 2", exception2.InnerException.ToString().Trim());

			MPException exception3 = new MPException("Some Exception message 3", "requestId", 666);
			Assert.AreEqual(string.Format("Mercadopago.Exceptions.MPException: Some Exception message 3; request-id: {0}; status_code: {1}", "requestId", 666), exception3.ToString().Trim());

			MPException exception4 = new MPException("Some Exception message 4", "requestId", 666, new MPException("InnerExceptionMessage 4"));
			Assert.AreEqual("Mercadopago.Exceptions.MPException: InnerExceptionMessage 4", exception4.InnerException.ToString().Trim());
		}
	}
}
