using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;
using booking.com_playwright_tests.my_ui_booking.activities;

namespace booking.com_playwright_tests.Tests;

public class LandingPage : BookingBaseTest
{
    [Fact]
    public async Task test_opening_landing_page()
    {
        // Use the Page Object
        var home = new Home(Page!);
        await home.Launch();

        Assert.True(await home.Loaded());

    }
}
