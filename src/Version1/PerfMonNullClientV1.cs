using System.Threading.Tasks;
using PipServices3.Commons.Data;

namespace PipServices.Perfmon.Client.Version1
{
    public class PerfMonNullClientV1 : IPerfMonClientV1
    {
        public async Task<DataPage<CounterV1>> ReadCountersAsync(string correlationId, FilterParams filter, PagingParams paging)
        {
            return await Task.FromResult(new DataPage<CounterV1>());
        }

        public async Task<CounterV1> WriteCounterAsync(string correlationId, CounterV1 counter)
        {
            return await Task.FromResult(new CounterV1());
        }

        public async Task WriteCountersAsync(string correlationId, CounterV1[] counters)
        {
            await Task.Delay(0);
        }

        public async Task Clear(string correlationId)
        {
            await Task.Delay(0);
        }
    }
}
