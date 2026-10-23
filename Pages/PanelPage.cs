using Microsoft.Playwright;
namespace SnipeIt.Pages.PanelPage;
public class PanelPage
{
    private IPage page;
    public PanelPage(IPage page)
    {
        this.page=page;
    }
    public ILocator createNewLink=>page.Locator("a:has-text('Create New')");  
    public ILocator createAssetOption=>page.Locator("a[href*='hardware/create']");
    public ILocator userInfoLocator=>page.Locator("li[class='dropdown user user-menu'] a span").First;

}