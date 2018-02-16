using System;
using Nancy;
using Nancy.Bootstrappers.StructureMap;
using StructureMap;
using Wreckastow.Models;
using Wreckastow.Services;

namespace Wreckastow
{
    public sealed class Bootstrapper : StructureMapNancyBootstrapper
    {
        protected override void ConfigureRequestContainer(IContainer container, NancyContext context)
        {
            base.ConfigureRequestContainer(container, context);
            container.Configure(conf =>  conf.For<IAlbumRepository>().Use(new AlbumRepositoryStub(new Album
                {
                    Title = "Purple Rain",
                    Artist = "Prince & The Revolution",
                    ReleaseDate = DateTime.Parse("1984-06-25"),
                    DateAvailable = DateTime.Parse("2017-12-24"),
                    Description =
                        @"Purple Rain (the motion picture soundtrack to the movie Purple Rain) is the sixth full-length 
studio album by Prince, and the first to be credited to Prince and the Revolution. 
It was released worldwide in June 1984, a month before the movie, Purple Rain opened in theaters."
                },
                new Album
                {
                    Title = "Lovesexy",
                    Artist = "Prince",
                    DateAvailable = DateTime.Parse(" 2018-02-12")
                },
                new Album
                {
                    Title = "Plectrumelectrum",
                    Artist = "3rdeyegirl",
                    DateAvailable = DateTime.Parse("2018-01-02")
                }
            )));
        }
    }
}