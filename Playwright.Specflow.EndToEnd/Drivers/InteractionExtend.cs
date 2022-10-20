using System.Threading.Tasks;
using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;

namespace Playwright.Specflow.EndToEnd.Drivers
{
    /* Wrapper Class around Playwright Methods*/
    public class InteractionExtend : Interactions
    {
        private readonly Task<IPage> _page1;

        public InteractionExtend(Task<IPage> page) : base(page)
        {
            _page1 = page;
        }

        public async Task GoToUrl1(string url)
        {
            await (await _page1).GotoAsync(url);
        }

    }
}