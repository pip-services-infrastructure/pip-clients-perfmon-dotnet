using PipServices.Perfmon.Client.Version1;
using PipServices3.Commons.Config;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Perfmon.Client.Test.Version1
{
    public class PerfMonHttpClientV1Test
    {
        private static readonly ConfigParams HttpConfig = ConfigParams.FromTuples(
            "connection.protocol", "http",
            "connection.host", "localhost",
            "connection.port", 8080
        );

        private PerfMonHttpClientV1 _client;
        private PerfMonClientFixtureV1 _fixture;

        public PerfMonHttpClientV1Test()
        {
            _client = new PerfMonHttpClientV1();
            _client.Configure(HttpConfig);

            _fixture = new PerfMonClientFixtureV1(_client);
            _client.OpenAsync(null);
        }

        public void Dispose()
        {
            _client.CloseAsync(null).Wait();
        }

        [Fact]
        public async Task TestCrudOperationsAsync()
        {
            await _fixture.TestCrudOperationsAsync();
        }
    }
}
