using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Wreckastow.Specs.StepDefinitions;

namespace WreckaStow.Specs.StepDefinitions
{
    [Binding]
    public sealed class StartPage
    {
        private readonly BrowserSteps _browser;
        private HtmlDocument _page;

        public StartPage(BrowserSteps browser)
        {
            _browser = browser;
        }

        [When(@"someone visits the start page")]
        public void Open()
        {
            _page = _browser.Get("/");
        }

        [Then(@"they see these albums:")]
        public void ShouldDisplayAlbums(Table table)
        {
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

        private static IEnumerable<string> GetAlbumTitles(HtmlDocument page)
        {
            return page
                .GetElementbyId("latest-albums")
                .ChildNodes
                .Where(x => x.HasClass("album"))
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