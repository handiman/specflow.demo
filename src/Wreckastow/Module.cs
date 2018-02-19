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

        private object Album(object arg)
        {
            return View["Details", new Album()];
        }

        private object Index(object arg)
        {
            return View["Index", Enumerable.Empty<Album>()];
        }
    }
}
