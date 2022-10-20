using Playwright.Specflow.EndToEnd.PageObjects;
using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Playwright.Specflow.EndToEnd.Hooks
{
    public class BazarHooks
    {
        private readonly string _traceName;

        public BazarHooks(ScenarioContext scenarioContext)
        {
            _traceName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
        }

        ///<summary>
        ///  Reset the calculator before each scenario tagged with "Calculator"
        /// </summary>
        [BeforeScenario("Smoke")]
        public async void BeforeScenarioAsync(DemoPage loginPageObject)
        {
            await loginPageObject.EnsureSellerBazarIsOpenAndResetAsync();
        }

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
