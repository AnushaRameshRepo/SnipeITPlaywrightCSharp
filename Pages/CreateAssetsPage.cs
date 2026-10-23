using Microsoft.Playwright;
using NUnit.Framework.Constraints;
namespace Pages.CreateAssetsPage;
public class CreateAssetsPage
{
    private IPage page;
    public CreateAssetsPage(IPage page)
    {
        this.page=page;
    }
    public ILocator modelDropDownLocator=>page.Locator("#select2-model_select_id-container");
    public ILocator modelDropdownOptions=>page.Locator("#select2-model_select_id-results");
    public ILocator assetStatusDropdownLocator=>page.GetByRole(AriaRole.Combobox).Filter(new(){HasText="Select Status"});
    public ILocator statusDropdownOptions=>page.Locator("#select2-status_select_id-results");
    public ILocator userDropdownLocator=>page.Locator("#select2-assigned_user_select-container");
    public ILocator assignedUserOptions=>page.Locator("#select2-assigned_user_select-results li");
    public ILocator assetTagLocator=>page.Locator("#asset_tag");
    public ILocator saveButton=>page.Locator("button[name='submit']");

    public async Task<(string assetTag, string assignedUser,string model)> createAsset(string modelOption, string statusOption)
    {
        var assetTag = $"Asset_{DateTime.Now:yyyyMMdd_HHmmss}";
        await assetTagLocator.FillAsync(assetTag);
        await modelDropDownLocator.ClickAsync();
        await modelDropdownOptions.Locator("li").Filter(new(){HasText=modelOption}).ClickAsync();
        await assetStatusDropdownLocator.ClickAsync();
        await statusDropdownOptions.Locator("li").Filter(new(){HasText=statusOption}).ClickAsync();
        await userDropdownLocator.ClickAsync();
        await assignedUserOptions.First.ClickAsync();
        var assignedUserDetail=await userDropdownLocator.GetAttributeAsync("title");
        var assignedUser=(assignedUserDetail.Split('('))[0].Trim();
        var model=await modelDropDownLocator.GetAttributeAsync("title");
        var modelNo=(model.Split('#'))[1].Replace(')',' ').Trim();
        await saveButton.ClickAsync();
        return (assetTag,assignedUser,modelNo);
    }

    public async Task<string> assignAsset()
    {
        await userDropdownLocator.ClickAsync();
        await assignedUserOptions.First.ClickAsync();
        return await userDropdownLocator.GetAttributeAsync("title");
        
    }
    
}