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
        private readonly DemoPage _demoObject;

        public LoginStepDefinitions(DemoPage DemoPageObject)
        {
            _demoObject = DemoPageObject;
        }

        [Given("I navigate to Demo Application")]
        public async Task GoToBazar()
        {
            //delegate to Page Object
            await _demoObject.EnsureSellerBazarIsOpenAndResetAsync();
        }

        
        [Then("Submit the Form")]
        public async Task WhenTheTwoNumbersAreAddedAsync()
        {
            await _demoObject.ClickSubmit();
        }

        [When("I enter following details")]
        public async Task ThenTheResultShouldBeAsync(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _demoObject.EnterDetails((string)data.FullName, (string)data.Email, (string)data.CurrentAddress, (string)data.PermanentAddress);
        }
    }
}