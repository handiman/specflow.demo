using System.Linq;
using HtmlAgilityPack;
using Nancy.Helpers;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Wreckastow.Models;
using Wreckastow.Services;
using Wreckastow.Specs.StepDefinitions;

namespace WreckaStow.Specs.StepDefinitions
{
    [Binding]
    public sealed class DetailsPage
    {
        private readonly BrowserSteps _browser;
        private readonly IAlbumRepository _albumRepository;
        private Album _album;
        private HtmlDocument _page;

        public DetailsPage(BrowserSteps browser, IAlbumRepository albumRepository)
        {
            _browser = browser;
            _albumRepository = albumRepository;
        }

        [When(@"someone selects the album from the list on the start page")]
        public void SelectAlbum()
        {
            _album = _albumRepository.All().Single();
            var relativeUrl = $"/album/{HttpUtility.UrlPathEncode(_album.Title)}";
            _page = _browser.Get(relativeUrl);
        }

        [Then(@"the page that opens displays the album information")]
        public void ShouldDisplayAlbum()
        {
            var actualTitle = _page
                .GetElementbyId("album-title")
                .InnerText
                .Trim();

            var actualReleaseDate = _page
                .GetElementbyId("album-release-date")
                .InnerText
                .Trim();

            var actualDescription = _page
                .GetElementbyId("album-description")
                .InnerText
                .Trim();

            Assert.That(actualTitle, Is.EqualTo(_album.Title), "Title");
            Assert.That(actualReleaseDate, Is.EqualTo(_album.ReleaseDate), "ReleaseDate");
            Assert.That(actualDescription, Is.EqualTo(_album.Description), "Description");
        }
    }
}

