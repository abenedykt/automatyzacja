using System.Linq;
using StaticPageObjectsWithExtensionMethod.TestFramework;

namespace FullObjectPageObjects.TestFramework
{
    internal class MainPage
    {
        private const string Url = "https://autotestdotnet.wordpress.com/";
        private readonly Browser _browser;


        public MainPage(Browser browser)
        {
            _browser = browser;
        }

        internal void Open()
        {
            _browser.NavigateTo(Url);
        }

        internal NotePage OpenFirstNote()
        {
            var elements = _browser.FindByXpath("//article/header");
            elements.First().Click();

            return new NotePage(_browser);
        }
    }
}