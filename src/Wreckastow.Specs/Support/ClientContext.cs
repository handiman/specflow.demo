using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;
using WreckaStow.Services;

namespace WreckaStow.Specs.Support
{
    [Binding]
    public sealed class ClientContext
    {
        private readonly IObjectContainer _container;

        private TestServer _server;
        private HttpClient _client;

        public ClientContext(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void StartWebServer()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _container.RegisterInstanceAs(_server.Services.GetService<IAlbumRepository>());
            _client = _server.CreateClient();
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _client?.Dispose();
            _server?.Dispose();
        }

        internal async Task<HtmlDocument> Get(string relativeUrl)
        {
            using var response = await _client.GetAsync(relativeUrl);
            
            var doc = new HtmlDocument();

            if (response.IsSuccessStatusCode)
            {
                doc.Load(await response.Content.ReadAsStreamAsync(), Encoding.UTF8);
            } 
            
            return doc;
        }
    }
}