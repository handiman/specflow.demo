using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WreckaStow.Models;
using WreckaStow.Services;

namespace WreckaStow.Pages
{
    public sealed class AlbumPage : PageModel
    {
        private readonly IAlbumRepository _repository;
        private Album _album;

        public AlbumPage(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public string Title => _album?.Title;
        public DateTime ReleaseDate => _album?.ReleaseDate ?? DateTime.MinValue;
        public string Description => _album?.Description;

        public void OnGet(string albumTitle)
        {
            _album = _repository.All().FirstOrDefault(album => album.Title.Equals(albumTitle, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
