using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Nancy.Testing;
using TechTalk.SpecFlow;

namespace Wreckastow.Specs.StepDefinitions
{
    [Binding]
    public sealed class BrowserSteps
    {
        private readonly Browser _browser;

        public BrowserSteps(Browser browser)
        {
            _browser = browser;
        }

        public HtmlDocument Get(string relativeUrl)
        {
            var response = _browser.Get(relativeUrl);
            var html = Encoding.UTF8.GetString(response.Body.ToArray());
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }
    }
}