using Microsoft.Playwright.NUnit;
using SnipeIt.Pages.PanelPage;
using Pages.AssetsPage;
using SnipeIt.Pages;
using Pages.CreateAssetsPage;
using Pages.AssetDetailsPage;
using NUnit.Framework.Interfaces;
using Microsoft.Playwright;

namespace SnipeIt.Test;

public class BaseTest : PageTest
{
    protected LoginPage loginPage;
    protected PanelPage panelPage; 
    protected AssetsPage assetsPage;
    protected CreateAssetsPage createAssetsPage;
    protected AssetDetailsPage assetDetailsPage;

    [SetUp]
    public async Task SetUpAsync()
    {
        loginPage = new LoginPage(Page);
        panelPage = new PanelPage(Page);
        assetsPage = new AssetsPage(Page);
        createAssetsPage = new CreateAssetsPage(Page);
        assetDetailsPage = new AssetDetailsPage(Page);

        await loginPage.login();
    }

    protected async Task VerifyAsync(params(ILocator,string Text)[] checks)
    {
        foreach(var (locator, text)in checks)
        {
            await Expect(locator).ToContainTextAsync(text);
        }
    }

     [TearDown]
    public async Task CaptureScreenshotOnFailureAsync()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed)
            return;

        var dir = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshots");
        Directory.CreateDirectory(dir);

        var fileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
        var path = Path.Combine(dir, fileName);

        await Page.ScreenshotAsync(new() { Path = path, FullPage = true });

        // Attach to the NUnit result so it shows up in reports
        TestContext.AddTestAttachment(path, "Failure screenshot");
    }
}