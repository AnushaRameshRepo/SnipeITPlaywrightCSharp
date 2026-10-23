using Microsoft.Playwright;
namespace Pages.AssetsPage;
public class AssetsPage
{
    private IPage page;
    public AssetsPage(IPage page)
    {
        this.page=page;
    }
    public ILocator addAssetButtonLocator=>page.Locator("button[name='btnAdd']");
    public ILocator assertCreatedStatusLocator=>page.Locator("div[class='alert alert-success fade in']");
    public ILocator searchTextboxLocator=>page.Locator("input[aria-label='Search']");
    public ILocator tabelAssetTagLocator=>page.Locator("tbody tr td a");
    
    public async Task searchAsset(string assetTag)
    {
        await searchTextboxLocator.FillAsync(assetTag);
        await searchTextboxLocator.PressAsync("Enter");
    }

}