using Playwright.Specflow.EndToEnd.PageObjects;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace Playwright.Specflow.EndToEnd.Hooks
{
    public class Hooks
    {
        private readonly string _traceName;

        public Hooks(ScenarioContext scenarioContext)
        {
            _traceName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
        }

        ///<summary>
        /// Action/steps need to complete before a specific scenario "Smoke"
        /// </summary>
        [BeforeScenario("Smoke")]
        public async void BeforeScenarioAsync(DemoPage loginPageObject)
        {
            await loginPageObject.EnsureSellerBazarIsOpenAndResetAsync();
        }

        ///<summary>
        /// Action/steps need to complete before each scenario
        /// </summary>
        [BeforeScenario]
        public async Task StartTracingAsync(DemoPage loginPageObject)
        {
            var tracing = await loginPageObject.Tracing;
            await tracing.StartAsync(new TracingStartOptions
            {
                Name = _traceName,
                Screenshots = true,
                Snapshots = true
            });
        }

        ///<summary>
        /// Action/steps need to complete After each scenario
        /// </summary>
        [AfterScenario]
        public async Task StopTracingAsync(DemoPage loginPageObject)
        {
            var tracing = await loginPageObject.Tracing;
            await tracing.StopAsync(new TracingStopOptions()
            {
                Path = $"traces/{_traceName}.zip"
            });
        }

    }
}
