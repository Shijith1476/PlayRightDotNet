using FluentAssertions;
using SpecFlow.Actions.Playwright;
using System.Threading.Tasks;

namespace Playwright.Specflow.EndToEnd.PageObjects
{
    public class DemoPage : BasePage
    {
        // The page URL
        private protected const string SellerUrl = "https://demoqa.com/text-box";

        //Finding elements by ID
        private static string FullName => "id=userName";
        private static string Email => "id=userEmail";
        private static string CurrentAddress => "id=currentAddress";
        private static string PermanentAddress => "id=permanentAddress";
        private static string Submit => "id=submit";

        private InteractionExtend _interactions;

        public DemoPage(BrowserDriver browserDriver) : base(browserDriver)
        {
            _interactions = new InteractionExtend(_page);
        }

        public async Task EnterDetails(string fullName, string email, string cAddress, string pAddress)
        {
            await _interactions.SendTextAsync(FullName, fullName);
            await _interactions.SendTextAsync(Email, email);
            await _interactions.SendTextAsync(CurrentAddress, cAddress);
            await _interactions.SendTextAsync(PermanentAddress, pAddress);
        }

        public async Task ClickSubmit()
        {
            await _interactions.ClickAsync(Submit);
        }

        public async Task EnsureSellerBazarIsOpenAndResetAsync()
        {         
                await _interactions.GoToUrl1(SellerUrl);
           
        }

    }
}
