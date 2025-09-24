using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace booking.com_playwright_tests.Tests;

public abstract class BookingBaseTest : IAsyncLifetime{
    protected IPlaywright? PlaywrightInstance; // nullable to avoid CS8618 warning
    protected IBrowser? Browser;
    protected IPage? Page;

    // Runs before each test class
    public async Task InitializeAsync(){
        // Use the static CreateAsync method
        PlaywrightInstance = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await PlaywrightInstance.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{
            Headless = false, // so that browser is visible
            Args = new[] { "--start-maximized" }, // Chrome/Edge supports this flag
            SlowMo = 100 // so that we can see whats happening
        });

        
        Page = await Browser.NewPageAsync(new BrowserNewPageOptions{
            ViewportSize = null // disables Playwright’s default viewport (lets window be maximized)
        });
    }

    // Runs after each test class
    public async Task DisposeAsync(){
        if (Browser != null) await Browser.CloseAsync();
        PlaywrightInstance?.Dispose();
    }
}
