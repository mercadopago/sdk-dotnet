using System.Threading.Tasks;
using MercadoPago.Config;

namespace MercadoPago.Snippets
{
    class MainClass
    {
        public async static Task Main(string[] args)
        {
            MercadoPagoConfig.AccessToken = "APP_USR-59441713004005-032712-65c33ef59c96727b0fcd9a1aa35cb70b-539675046";

            //await CheckoutTransparente.CreateBasicPayment.SnippetAsync();

            //await Search.SearchPayment.SearchAsync();

            //await CheckoutPro.SimpleIntegration.Create();

            //await CheckoutPro.AdvancedIntegration.Create();

            //await CheckoutPro.OtherFeatures.Create();

            await Get.GetPreference.GetAsync();
        }
    }
}
