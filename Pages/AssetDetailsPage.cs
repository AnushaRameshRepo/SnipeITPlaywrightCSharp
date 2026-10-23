using Microsoft.Playwright;
namespace Pages.AssetDetailsPage;
public class AssetDetailsPage
{
    private IPage page;
    public AssetDetailsPage(IPage page)
    {
        this.page=page;
    }
    public ILocator statusLocator=>page.Locator("div[class='col-md-4'] div").First;
    public ILocator assignedUserLocator=>page.Locator("div[class='col-md-4'] a[href*='users']");
    public ILocator assetTagLocator=>page.Locator("span[class='js-copy-asset_tag']");
    public ILocator assetCreatedByLocator=>page.Locator("#created-by a");
    public ILocator assetModelLocator=>page.Locator("span[class='js-copy-asset_model'] a");
    public ILocator assetModelNoLocator=>page.Locator("span[class='js-copy-model_number']");

}