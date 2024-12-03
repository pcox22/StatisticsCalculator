using System.Net.Mime;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightUITest;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    public string URL = "https://localhost:7150";

    //preq-E2E-TEST-5
    [Test]
    public async Task VerifyPageTitle()
    {
        // Gather the title page and compare it against the expected title
        await Page.GotoAsync(URL);
        string pageTitle = await Page.TitleAsync();
        Assert.That(pageTitle, Is.EqualTo("Calculator"));
        
        await Expect(Page).ToHaveTitleAsync(new Regex("Calculator"));

    }

    // preq-UNIT-TEST-6
    [Test]
    public async Task StandardDeviation_SeveralNumbers_ReturnsCorrectly()
    {
        // First half of methods were written before working with Playwright's test generator
        await Page.GotoAsync(URL);
        string textFieldResult;
        
        // Locate the input field and enter values (one per line)
        var inputField = Page.Locator("textarea");
        var stdButton = Page.Locator("text=Compute Sample Standard Deviation | one value per line");
        
        await inputField.FillAsync("9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4");
        await stdButton.ClickAsync();
        
        // Please forgive defying Arrange-Act-Assert;
        // for some reason I could not get Playwright to detect this area in the default state
        var results = Page.Locator("text=Sample Standard Deviation: ");
        textFieldResult = await results.TextContentAsync();
        
        Assert.That(textFieldResult, Is.EqualTo("Sample Standard Deviation: 3.0607876523260447"));
    }
    
    // preq-UNIT-TEST-7
    [Test]
    public async Task PopulationSTD_Empty_ReturnsError()
    {
        await Page.GotoAsync(URL);
        
        // Locate the input field and enter values (one per line)
        var inputField = Page.Locator("textarea");
        var stdButton = Page.Locator("text=Compute Population Standard Deviation | one value per line");

        var clearButton = Page.Locator("text=Clear");
        await clearButton.ClickAsync();
        
        await stdButton.ClickAsync();
        var results = Page.Locator("text=Error: Input cannot be empty");
        
        string resultsText = await results.TextContentAsync();
        Assert.That(resultsText, Is.EqualTo("Error: Input cannot be empty."));
    }
    
    // preq-UNIT-TEST-8
    [Test]
    public async Task SampleSTD_OneNumber_ReturnsNaN()
    {
        await Page.GotoAsync(URL);
        var stdButton = Page.Locator("text=Compute Sample Standard Deviation");
        var inputField = Page.Locator("textarea");

        await inputField.FillAsync("7");
        
        await stdButton.ClickAsync();
        var results = Page.Locator("text=Sample Standard Deviation: NaN");
        string resultsText = await results.TextContentAsync();
        
        Assert.That(resultsText, Is.EqualTo("Sample Standard Deviation: NaN"));
    }
    
    // preq-UNIT-TEST-9
    [Test]
    public async Task ComputeMean_SeveralNumbers_ReturnsCorrectly()
    {
        await Page.GotoAsync(URL);
        
        var inputField = Page.Locator("textarea");
        var meanButton = Page.Locator("text=Compute Mean");

        await inputField.FillAsync("9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4");
        await meanButton.ClickAsync();
        
        var result = Page.Locator("text=Mean:");
        string resultsText = await result.TextContentAsync();
        
        Assert.That(resultsText, Is.EqualTo("Mean: 7"));
    }
    
    // preq-UNIT-TEST-10
    [Test]
    public async Task ZScore_GivenNumbers_ReturnsCorrectly()
    {
        await Page.GotoAsync("https://localhost:7150/");
        await Page.Locator("#values").ClickAsync();
        await Page.Locator("#values").FillAsync("5.5,7,3.060787652326");
        await Page.Locator("text=>Compute Z Score").ClickAsync();
        await Page.GetByText("Z-Score: -").ClickAsync();
        await Expect(Page.GetByRole(AriaRole.Main)).ToContainTextAsync("Z-Score: -0.49006993309715474");
    }
    
    // preq-UNIT-TEST-11
    [Test]
    public async Task SingleLinearRegression_GivenNumbers_ReturnsCorrectly()
    {
        await Page.GotoAsync("https://localhost:7150/");
        await Page.Locator("#values").ClickAsync();
        await Page.Locator("#values").FillAsync("5,3\n3,2\n2,15\n1,12.3\n7.5,-3\n4,5\n3,17\n4,3\n6.42,4\n34,5\n,12,17\n,3,-1");
        await Page.Locator("text=Compute Single Linear Regression Formula").ClickAsync();
        
        await Expect(Page.GetByRole(AriaRole.Main)).ToContainTextAsync("Y = -0.045961532930936355x + 6.933587781374592");
    }
    
    // preq-UNIT-TEST-12
    [Test]
    public async Task YFromRegression_GivenInputs_ReturnsCorrectly()
    {
        await Page.GotoAsync("https://localhost:7150/");
        await Page.Locator("#values").ClickAsync();
        await Page.Locator("#values").FillAsync("6,-0.04596,6.9336");
        await Page.Locator("text=Compute Y from Linear Regression Formula").ClickAsync();
        
        await Expect(Page.GetByRole(AriaRole.Main)).ToContainTextAsync("Y = 6.65784");
    }
    
}