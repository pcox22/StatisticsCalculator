using Microsoft.Playwright;

namespace PlaywrightUITest;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    public string URL = "https://localhost:7150";
    
    // Default playwright test
    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await Page.GotoAsync(URL);

        // Expect a title "to contain" a substring.
        //await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.Locator("text=Calculator");
        var clearButton = Page.Locator("text=Clear");
        var textField = Page.Locator("//input[@id='values']");

        // Expect an attribute "to be strictly equal" to the value.
        //await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        //await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        //await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));

        await Browser.CloseAsync();
    }

    public async Task ClearButtonRemovesEntriesFromTextField()
    {

        // Navigate to the target page
        await Page.GotoAsync(URL);

        // Locate the input field and enter values (one per line)
        var inputField = Page.Locator("textarea");
        var clearButton = Page.Locator("text=Clear");
        
        await inputField.FillAsync("5\n10\n15");
        await clearButton.ClickAsync();
        
        // Currently trying to figure out Playwright syntax and documentation
        // The following is meant to check whether or not the text field still contains any elements
        //Expect(inputField.TextContentAsync() == null);
        

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
    }
}