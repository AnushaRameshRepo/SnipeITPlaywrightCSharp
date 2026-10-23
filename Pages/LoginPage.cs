using Microsoft.Playwright;
using Microsoft.VisualBasic;
using SnipeIt.Config;

namespace SnipeIt.Pages;
public class LoginPage
{
    private IPage page;
    public LoginPage(IPage page)
    {
        this.page=page;
    }
    private ILocator usernameTextboxLocator=>page.GetByPlaceholder("Username");
    private ILocator passwordTextboxLocator=>page.GetByPlaceholder("password");
    private ILocator rememberMeCheckboxLocator=>page.Locator("#remember");
    private ILocator loginButtonLocator=>page.Locator("#submit");

    public async Task login()
    {
        await page.GotoAsync("https://demo.snipeitapp.com/login");
        await usernameTextboxLocator.FillAsync(appConfig.Username);
        await passwordTextboxLocator.FillAsync(appConfig.Password);
        await loginButtonLocator.ClickAsync();
    }
}