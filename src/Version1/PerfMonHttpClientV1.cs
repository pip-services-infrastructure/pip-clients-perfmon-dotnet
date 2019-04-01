using System.Threading.Tasks;
using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using PipServices3.Commons.Refer;
using PipServices3.Components.Count;
using PipServices3.Components.Log;
using PipServices3.Rpc.Clients;

namespace PipServices.Perfmon.Client.Version1
{
    public class PerfMonHttpClientV1 : CommandableHttpClient, IPerfMonClientV1
    {
        public PerfMonHttpClientV1() : base("v1/perfmon") { }

        public PerfMonHttpClientV1(object config) : base("v1/perfmon")
        {
            if (config != null)
                this.Configure(ConfigParams.FromValue(config));
        }

        public override void SetReferences(IReferences references)
        {
            base.SetReferences(references);
            this._logger = new CompositeLogger();
            this._counters = new CompositeCounters();
        }

        public async Task<DataPage<CounterV1>> ReadCountersAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<DataPage<CounterV1>>(
                    "read_counters",
                    correlationId,
                    new
                    {
                        filter = filter,
                        paging = paging
                    }
                    );
            }
        }

        public async Task<CounterV1> WriteCounterAsync(string correlationId, CounterV1 counter)
        {
            using (var timing = Instrument(correlationId))
            {
                return await CallCommandAsync<CounterV1>(
                    "write_counter",
                    correlationId,
                    new
                    {
                        counter = counter
                    }
                    );
            }
        }

        public async Task WriteCountersAsync(string correlationId, CounterV1[] counters)
        {
            using (var timing = Instrument(correlationId))
            {
                await CallCommandAsync<Task>(
                    "write_counters",
                    correlationId,
                    new
                    {
                        counters = counters
                    }
                    );
            }
        }

        public async Task Clear(string correlationId)
        {
            using (var timing = Instrument(correlationId))
            {
                await CallCommandAsync<Task>(
                    "clear",
                    correlationId,
                    new { }
                    );
            }
        }
    }
}
