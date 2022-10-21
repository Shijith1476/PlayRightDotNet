using Playwright.Specflow.EndToEnd.PageObjects;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using Newtonsoft.Json.Linq;
using FluentAssertions;

namespace Playwright.Specflow.EndToEnd.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        //Page Object for Demo Page
        private readonly DemoPage _demoObject;

        public LoginStepDefinitions(DemoPage DemoPageObject)
        {
            _demoObject = DemoPageObject;
        }

        [Given("I navigate to Demo Application")]
        public async Task GoToBazar()
        {
            await _demoObject.EnsureSellerBazarIsOpenAndResetAsync();
        }

        
        [Then("Submit the Form and verify the details")]
        public async Task WhenTheTwoNumbersAreAddedAsync(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _demoObject.ClickSubmit();
            var actualName = await _demoObject.WaitForNonEmptyResultAsync("name");
            var actualemail = await _demoObject.WaitForNonEmptyResultAsync("email");
            var actualCurrent = await _demoObject.WaitForNonEmptyResultAsync("current");
            var actualPermanet = await _demoObject.WaitForNonEmptyResultAsync("permanent");

            actualName.Should().Be("Name:"+(string)data.FullName);
            actualemail.Should().Be("Email:"+(string)data.Email);
            actualCurrent.Trim().Should().Be("Current Address :" + (string)data.CurrentAddress);
            actualPermanet.Should().Be("Permananet Address :"+(string)data.PermanentAddress);
        }

        [When("I enter following details")]
        public async Task ThenTheResultShouldBeAsync(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _demoObject.EnterDetails((string)data.FullName, (string)data.Email, (string)data.CurrentAddress, (string)data.PermanentAddress);
        }
    }
}