
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using SnipeIt.Pages.PanelPage;
using Pages.AssetsPage;
using SnipeIt.Pages;
using Pages.CreateAssetsPage;
using Pages.AssetDetailsPage;

namespace SnipeIt.Test.CreateAsset;

[TestFixture]
public class CreateAssetTest:BaseTest
{
    [Test]
    public async Task CreateAssetCommonTest()
    {
        
        await panelPage.createNewLink.ClickAsync();
        await panelPage.createAssetOption.ClickAsync();
        var createdAsset=await createAssetsPage.createAsset("Laptops - Macbook Pro 13","Ready to Deploy");
        await Expect(assetsPage.assertCreatedStatusLocator).ToBeVisibleAsync();
        Console.WriteLine(createdAsset.assetTag);
        await assetsPage.searchAsset(createdAsset.assetTag);
        await Expect(assetsPage.tabelAssetTagLocator.First).ToContainTextAsync(createdAsset.assetTag);
        await assetsPage.tabelAssetTagLocator.First.ClickAsync();
        await assetDetailsPage.assignedUserLocator.WaitForAsync();
        await VerifyAsync(
            (assetDetailsPage.statusLocator,"Ready to Deploy"),
            (assetDetailsPage.assignedUserLocator,createdAsset.assignedUser),
            (assetDetailsPage.assetCreatedByLocator, await panelPage.userInfoLocator.TextContentAsync()),
            (assetDetailsPage.assetModelLocator, "Macbook Pro 13"),
            (assetDetailsPage.assetModelNoLocator, createdAsset.model));

    }
}