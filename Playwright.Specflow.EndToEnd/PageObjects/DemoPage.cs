using Playwright.Specflow.EndToEnd.Drivers;
using SpecFlow.Actions.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace Playwright.Specflow.EndToEnd.PageObjects
{
    public class DemoPage : BasePage
    {
        // The page URL
        private protected const string DemoUrl = "https://demoqa.com/text-box";

        //Finding elements by ID
        private static string FullName => "id=userName";
        private static string Email => "id=userEmail";
        private static string CurrentAddress => "id=currentAddress";
        private static string PermanentAddress => "id=permanentAddress";
        private static string Submit => "id=submit";
        private static string NameText => "#output>div>#name";
        private static string EmailText => "#output>div>#email";
        private static string CurrentAddressText => "#output>div>#currentAddress";
        private static string PermanentAddressText => "#output>div>#permanentAddress";
        private static string CheckboxTab => "text=Check Box";
        private static string HomeCheckbox => "text=Home";
        private static string CheckboxText => "#result";

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
                await _interactions.GoToUrl(DemoUrl);
           
        }
        public async Task<string?> VerifyContentTextbox(string type)
        {
            switch(type) {
                case "name":
                    return await _interactions.TextContentAsync(NameText);
                case "email":
                    return await _interactions.TextContentAsync(EmailText);
                case "current":
                    return await _interactions.TextContentAsync(CurrentAddressText);
                case "permanent":
                    return await _interactions.TextContentAsync(PermanentAddressText);
                    default:break;
            }
            return null;
        }

        public async Task<string?> VerifyCheckboxText()
        {
            return await _interactions.TextContentAsync(CheckboxText);
        }

            public async Task ClickCheckBox()
        {
            await _interactions.ClickAsync(CheckboxTab);
            await _interactions.CheckAsync(HomeCheckbox);
        }

    }
}
