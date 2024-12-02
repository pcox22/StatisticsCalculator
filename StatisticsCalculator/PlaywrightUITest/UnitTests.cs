using System.Net.Mime;
using Microsoft.Playwright;

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
        await Browser.CloseAsync();
        
        /*

        // Locate the input field and enter values (one per line)
        var inputField = Page.Locator("textarea");
        var clearButton = Page.Locator("text=Clear");
        
        await inputField.FillAsync("5\n10\n15");
        

        // All code from here is sample snippets that will be delegated into unique tests for different functions
        
        // Test Sample Standard Deviation
        await Page.ClickAsync("button:has-text('Compute Sample Standard Deviation')");
        var sampleStdDevResult = await Page.Locator("result-selector").TextContentAsync(); // Replace "result-selector" with the actual result locator
        Assert.That(sampleStdDevResult, Is.EqualTo("5")); // Replace with expected result

        // Test Population Standard Deviation
        await Page.ClickAsync("button:has-text('Compute Population Standard Deviation')");
        var populationStdDevResult = await Page.Locator("result-selector").TextContentAsync(); // Replace "result-selector" with the actual result locator
        Assert.That(populationStdDevResult, Is.EqualTo("4.08")); // Replace with expected result

        // Test Mean
        await Page.ClickAsync("button:has-text('Compute Mean')");
        var meanResult = await Page.Locator("result-selector").TextContentAsync(); // Replace "result-selector" with the actual result locator
        Assert.That(meanResult, Is.EqualTo("10")); // Replace with expected result

        // Test Z-Score
        await inputField.FillAsync("10\n10\n5"); // Example inputs: value, mean, stdDev
        await Page.ClickAsync("button:has-text('Compute Z Score')");
        var zScoreResult = await Page.Locator("result-selector").TextContentAsync(); // Replace "result-selector" with the actual result locator
        Assert.That(zScoreResult, Is.EqualTo("0")); // Replace with expected result
        

        // Close the browser
        await Browser.CloseAsync();
        */
    }

    // preq-UNIT-TEST-6
    [Test]
    public async Task ComputeSampleStandardDeviation()
    {
        await Page.GotoAsync(URL);
        const double expectedStandardDeviation = 3.060787652326F;
        double sampleSTD = 0;
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
        await Browser.CloseAsync();
    }
    
    // preq-UNIT-TEST-7
    [Test]
    public async Task ComputePopulationStandardDeviationFails()
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
    public async Task ComputePopulationStandardDeviationFails2()
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
    public async Task ComputeMean()
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
    public async Task ComputeZScore()
    {
        
    }
    
    // preq-UNIT-TEST-11
    [Test]
    public async Task ComputeSingleLinearRegression()
    {
        
    }
    
    // preq-UNIT-TEST-12
    [Test]
    public async Task ComputeYFromRegression()
    {
        
    }
    
}