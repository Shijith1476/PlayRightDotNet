using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;
using System.Collections.Generic;

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

        public async Task CheckAsync(string selector)
        {
            await (await _page).CheckAsync(selector);
        }

    }
}