using System.Threading.Tasks;
using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace Playwright.Specflow.EndToEnd.Drivers
{
    /* Wrapper Class around Playwright Methods*/
    public class InteractionExtend : Interactions
    {
        private readonly Task<IPage> _page;

        public InteractionExtend(Task<IPage> page) : base(page)
        {
            _page = page;
        }

        public async Task<string?> TextContentAsync(string selector)
        {
            return await (await _page).TextContentAsync(selector);
        }

    }
}