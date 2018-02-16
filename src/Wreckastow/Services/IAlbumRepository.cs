using System.Collections.Generic;
using Wreckastow.Models;

namespace Wreckastow.Services
{
    public interface IAlbumRepository
    {
        void Save(Album album);
        IEnumerable<Album> All();
    }
}