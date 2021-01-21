using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WreckaStow.Models;
using WreckaStow.Services;
using WreckaStow.Specs.Support;

namespace WreckaStow.Specs
{
    [Binding]
    public sealed class AlbumDetails
    {
        private readonly ClientContext _browser;
        private readonly IAlbumRepository _albumRepository;
        private Album _album;
        private HtmlDocument _page;

        public AlbumDetails(ClientContext browser, IAlbumRepository albumRepository)
        {
            _browser = browser;
            _albumRepository = albumRepository;
        }

        [When(@"someone selects the album from the list on the start page")]
        public async Task SelectAlbum()
        {
            _album = _albumRepository.All().First();
            var relativeUrl = $"/album/{HttpUtility.UrlPathEncode(_album.Title)}";
            _page = await _browser.Get(relativeUrl);
        }

        [Then(@"the page that opens displays the album information")]
        public void ShouldDisplayAlbum()
        {
            var actualTitle = _page
                .GetElementbyId("album-title")
                .InnerText
                .HtmlDecode()
                .Trim();

            var actualReleaseDate = _page
                .GetElementbyId("album-release-date")
                .InnerText
                .HtmlDecode()
                .Trim();

            var actualDescription = _page
                .GetElementbyId("album-description")
                .InnerText
                .HtmlDecode()
                .Trim();

            Assert.That(actualTitle, Is.EqualTo(_album.Title), "Title");
            Assert.That(actualReleaseDate, Is.EqualTo(_album.ReleaseDate.ToString("Y")), "ReleaseDate");
            Assert.That(actualDescription, Is.EqualTo(_album.Description), "Description");
        }
    }
}

