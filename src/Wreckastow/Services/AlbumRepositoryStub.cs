using System.Collections.Generic;
using System.Linq;
using Wreckastow.Models;

namespace Wreckastow.Services
{
    public sealed class AlbumRepositoryStub : IAlbumRepository
    {
        private readonly IList<Album> _albums;

        public AlbumRepositoryStub(params Album[] albums)
        {
            _albums = albums.ToList();
        }

        void IAlbumRepository.Save(Album album)
        {
            if (_albums.Any(x => x.Title == album.Title))
            {
                return;
            }

            _albums.Add(album);
        }

        IEnumerable<Album> IAlbumRepository.All()
        {
            return _albums;
        }
    }
}