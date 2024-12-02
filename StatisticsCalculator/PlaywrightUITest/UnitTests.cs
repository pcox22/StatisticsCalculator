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
}