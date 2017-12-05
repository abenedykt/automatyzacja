using System.Linq;

namespace StaticPageObjectsWithExtensionMethod.TestFramework
{
    internal static class MainPage
    {
        private const string url = "https://autotestdotnet.wordpress.com/";

        internal static void MainPageOpen(this Browser browser)
        {
            browser.NavigateTo(url);
        }

        internal static void MainPageOpenFirstNote(this Browser browser)
        {
            var elements = browser.FindByXpath("//article/header");
            elements.First().Click();
        }
    }
}