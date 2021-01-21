using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using WreckaStow.Models;
using WreckaStow.Services;

namespace WreckaStow.Pages
{
    public sealed class IndexPage : PageModel
    {
        private readonly IAlbumRepository _repository;

        public IndexPage(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Album> Albums => _repository.All().OrderByDescending(album => album.DateAvailable);
    }
}
