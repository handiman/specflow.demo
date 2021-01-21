using System.Collections.Generic;
using WreckaStow.Models;

namespace WreckaStow.Services
{
    public interface IAlbumRepository
    {
        void Save(Album album);
        IEnumerable<Album> All();
    }
}