using System.Threading.Tasks;
using Microsoft.Playwright;

namespace booking.com_playwright_tests.my_ui_booking.activities;

public class Currency
{
    private const string SELECT_CURRENCY_HEADING_LOCATOR = "//h2[text()='Select your currency']/..";
    private const string CURRENCY_TEXT = "Select your currency";

    private readonly IPage _page;
    private readonly Home _home;

    public Currency(IPage page)
    {
        _page = page;
        _home = new Home(_page);
    }

    public async Task Launch()
    {
        await _home.CurrencyButton().ClickAsync();
    }

    public async Task<bool> Loaded()
    {
        var heading = _page.Locator(SELECT_CURRENCY_HEADING_LOCATOR);
        return (await heading.InnerTextAsync()) == CURRENCY_TEXT;

    }
    
}
