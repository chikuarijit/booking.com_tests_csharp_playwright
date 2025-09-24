using System.Threading.Tasks;
using Microsoft.Playwright;

namespace booking.com_playwright_tests.my_ui_booking.activities;

public class Home
{

    // Locator constant
    private const string BOOKING_LOGO_LOCATOR = "a[data-testid='header-booking-logo']";

    private readonly IPage _page;

    public Home(IPage page){
        _page = page;
    }

    public async Task Launch(){
        await _page.GotoAsync("https://www.booking.com");
    }

    public async Task<bool> Loaded()
    {
        // Wait until logo is visible
        await BookingLogo().WaitForAsync();

        // Optional: also check title to be extra sure
        var title = await _page.TitleAsync();
        return title.Contains("Booking.com");
    }

    public ILocator BookingLogo() {
        return _page.Locator(BOOKING_LOGO_LOCATOR);
    }
}