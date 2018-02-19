using System;
using System.Linq;
using Nancy;
using Wreckastow.Models;
using Wreckastow.Services;

namespace Wreckastow
{
    public sealed class Module : NancyModule
    {
        private readonly IAlbumRepository _albums;

        public Module(IAlbumRepository albums)
        {
            _albums = albums;
            Get["/"] = Index;
            Get["/album/{title}"] = Album;
        }

        private object Album(dynamic arg)
        {
            var album = _albums.All().Single(x => string.Equals(x.Title, arg.title.ToString(), StringComparison.InvariantCultureIgnoreCase));
            return View["Details", album];
        }

        private object Index(object arg)
        {
            var model = _albums.All().OrderByDescending(x => x.DateAvailable);
            return View["Index", model];
        }
    }
}
