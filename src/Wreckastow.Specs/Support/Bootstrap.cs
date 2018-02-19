using BoDi;
using Nancy.Testing;
using TechTalk.SpecFlow;
using Wreckastow;
using Wreckastow.Services;

namespace WreckaStow.Specs.Support
{
    [Binding]
    public sealed class Bootstrap
    {
        private readonly IObjectContainer _container;
        private Bootstrapper _bootstrapper;

        public Bootstrap(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario(Order = int.MinValue)]
        public void BeforeScenario()
        {
            var albumRepository = new AlbumRepositoryStub();
            _bootstrapper = new Bootstrapper(conf => conf
                .For<IAlbumRepository>()
                .Use(albumRepository)
                .Singleton());

            _container.RegisterInstanceAs<IAlbumRepository>(albumRepository);
            _container.RegisterInstanceAs(new Browser(_bootstrapper));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try { _bootstrapper.Dispose(); }
            catch { /* Ignore */ }
        }
    }
}