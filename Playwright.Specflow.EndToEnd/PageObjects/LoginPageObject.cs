using FluentAssertions;
using SpecFlow.Actions.Playwright;
using System.Threading.Tasks;

namespace Playwright.Specflow.EndToEnd.PageObjects
{
    public class LoginPageObject : BasePage
    {
        // The page URL
        private protected const string SellerUrl = "https://mystaging.shopbazar.com/seller/auth/login";

        //Finding elements by ID
        private static string EmailFieldSelector => "[placeholder=\"youremail\\@example\\.com\"]";
        private static string PasswordFieldSelector => "input[name=\"password\"]";
        private static string LoginButtonSelector => "text=Login";
        private static string WelcomeLabelSelector => "text=WELCOME BACK!";
        private static string BazarTextSelector => "text=My Bazar";

        private Interactions _interactions;

        public LoginPageObject(BrowserDriver browserDriver) : base(browserDriver)
        {
            _interactions = new Interactions(_page);
        }

        public async Task Login(string emailText, string passwordText)
        {
            //Enter text
            await _interactions.SendTextAsync(EmailFieldSelector, emailText);
            await _interactions.SendTextAsync(PasswordFieldSelector, passwordText);
        }

        public async Task ClickLogin()
        {
            //Click the add button
            await _interactions.ClickAsync(LoginButtonSelector);
        }

        public async Task EnsureSellerBazarIsOpenAndResetAsync()
        {
            //Open the calculator page in the browser if not opened yet
            
                await _interactions.GoToUrl(SellerUrl);
           
        }

    }
}
