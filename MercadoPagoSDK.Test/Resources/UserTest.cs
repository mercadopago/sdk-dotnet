using MercadoPago.Resources;
using NUnit.Framework;

namespace MercadoPagoSDK.Test.Resources
{
    [TestFixture]
    public class UserTest : BaseResourceTest
    {
        [Test]
        public void UserFindTest()
        {
            var user = User.Find();
            Assert.IsNull(user.Errors);
            Assert.IsNotNull(user.Id);
        }
    }
}
