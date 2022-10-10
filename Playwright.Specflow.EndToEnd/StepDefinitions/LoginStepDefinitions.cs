using Playwright.Specflow.EndToEnd.PageObjects;
using TechTalk.SpecFlow.Assist;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace Playwright.Specflow.EndToEnd.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        //Page Object for Calculator
        private readonly LoginPageObject _LoginPageObject;

        public LoginStepDefinitions(LoginPageObject LoginPageObject)
        {
            _LoginPageObject = LoginPageObject;
        }

        [Given("I navigate to Seller Portal Application")]
        public async Task GoToBazar()
        {
            //delegate to Page Object
            await _LoginPageObject.EnsureSellerBazarIsOpenAndResetAsync();
        }

        
        [Then("I see the May Bazar Dashboard")]
        public async Task WhenTheTwoNumbersAreAddedAsync()
        {
            //delegate to Page Object
            await _LoginPageObject.ClickLogin();
        }

        [When("I enter following login details")]
        public async Task ThenTheResultShouldBeAsync(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _LoginPageObject.Login((string)data.Email, (string)data.Password);
        }
    }
}