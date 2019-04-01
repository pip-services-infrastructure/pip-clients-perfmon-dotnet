using PipServices3.Commons.Data;
using System.Threading.Tasks;

namespace PipServices.Perfmon.Client.Version1
{
    public interface IPerfMonClientV1
    {
        Task<DataPage<CounterV1>> ReadCountersAsync(string correlationId,
           FilterParams filter, PagingParams paging);
        Task<CounterV1> WriteCounterAsync(string correlationId, CounterV1 counter);
        Task WriteCountersAsync(string correlationId, CounterV1[] counters);
        Task Clear(string correlationId);
    }
}
