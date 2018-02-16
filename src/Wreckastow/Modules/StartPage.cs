using Nancy;
using Wreckastow.Services;

namespace Wreckastow.Modules
{
    public sealed class Module : NancyModule
    {
        private readonly IAlbumRepository _albums;

        public Module(IAlbumRepository albums)
        {
            _albums = albums;
            Get["/"] = Index;
        }

        private object Index(object arg)
        {
            var model = _albums.All();
            return View["Index", model];
        }
    }
}
