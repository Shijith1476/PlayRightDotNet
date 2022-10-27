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

        [Then("Submit the Form and verify the details")]
        public async Task SubmitVerify(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _demoObject.ClickSubmit();
            var actualName = await _demoObject.VerifyContentTextbox("name");
            var actualemail = await _demoObject.VerifyContentTextbox("email");
            var actualCurrent = await _demoObject.VerifyContentTextbox("current");
            var actualPermanet = await _demoObject.VerifyContentTextbox("permanent");

            actualName.Should().Be("Name:" + (string)data.FullName);
            actualemail.Should().Be("Email:" + (string)data.Email);
            actualCurrent.Trim().Should().Be("Current Address :" + (string)data.CurrentAddress);
            actualPermanet.Should().Be("Permananet Address :" + (string)data.PermanentAddress);
        }

        [Given("I enter following User details")]
        public async Task FillDetail(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _demoObject.EnterDetails((string)data.FullName, (string)data.Email, (string)data.CurrentAddress, (string)data.PermanentAddress);
        }

        [Given("I click the Home checkbox option")]
        public async Task ClickCheckbox()
        {
            await _demoObject.ClickCheckBox();
        }
        [Then("Verify the details '(.*)'")]
        public async Task CheckboxVerify(string text)
        {
            var checkboxText = await _demoObject.VerifyCheckboxText();
            checkboxText.Should().Contain(text);
        }
    }
}