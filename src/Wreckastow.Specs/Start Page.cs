using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WreckaStow.Specs.Support;

namespace WreckaStow.Specs
{
    [Binding]
    public sealed class StartPage
    {
        private readonly ClientContext _browser;
        private HtmlDocument _page;
        private Table _albums;

        public StartPage(ClientContext browser)
        {
            _browser = browser;
        }

        [When(@"someone visits the start page")]
        public async Task Open()
        {
            _page = await _browser.Get("/");
        }

        [Then(@"they see these albums:")]
        public void ShouldDisplayAlbums(Table table)
        {
            _albums = table;
            var expectedTitles = GetAlbumTitles(table);
            var actualTitles = GetAlbumTitles(_page);
            Assert.That(actualTitles, Is.EquivalentTo(expectedTitles));
        }

        [Then(@"they see these albums in this order:")]
        public void ShouldDisplayAlbumsInOrder(Table table)
        {
            var expectedTitles = GetAlbumTitles(table);
            var actualTitles = GetAlbumTitles(_page);
            Assert.That(actualTitles, Is.EqualTo(expectedTitles));
        }

        [Then(@"each album has a link to its details page")]
        public void ShouldLinkToDetailsPage()
        {
            var expectedUrls = _albums
                .Rows
                .Select(row => $"/album/{HttpUtility.UrlPathEncode(row[0])}".ToLowerInvariant())
                .ToList();

            var actualUrls = _page
                .GetElementbyId("latest-albums")
                .Elements("li")
                .SelectMany(x => x.Elements("h4"))
                .SelectMany(x => x.Elements("a"))
                .Select(x => x.Attributes["href"].Value)
                .ToList();

            Assert.That(actualUrls, Is.EquivalentTo(expectedUrls));
        }

        private static IEnumerable<string> GetAlbumTitles(HtmlDocument page)
        {
            return page
                .GetElementbyId("latest-albums")
                .Elements("li")
                .Select(x => x.InnerText.Trim())
                .ToList();
        }

        private static IEnumerable<string> GetAlbumTitles(Table table)
        {
            return table
                .Rows
                .Select(row => row[0])
                .ToList();
        }
    }
}