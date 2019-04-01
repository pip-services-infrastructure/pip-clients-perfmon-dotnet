using PipServices.Perfmon.Client.Version1;
using PipServices3.Commons.Data;
using PipServices3.Components.Count;
using System.Threading.Tasks;
using Xunit;

namespace PipServices.Perfmon.Client.Test.Version1
{
    public class PerfMonClientFixtureV1
    {
        private IPerfMonClientV1 _client;

        public PerfMonClientFixtureV1(IPerfMonClientV1 client)
        {
            _client = client;
        }

        public async Task TestCrudOperationsAsync()
        {
            CounterV1 counter = new CounterV1("counter1", "source1", CounterTypeV1.Statistics, 5, 2, 2, 5, 3.5);
            counter.Count = 1;
            counter.Max = 10;
            counter.Min = 1;
            counter.Average = 5;

            var test_counter = await this._client.WriteCounterAsync(null, counter);
            Assert.NotNull(test_counter);

            CounterV1 counter1 = new CounterV1("counter1", "source1", CounterTypeV1.Statistics, 5, 2, 2, 5, 3.5);
            counter1.Count = 2;
            counter1.Max = 7;
            counter1.Min = 0;
            counter1.Average = 5;

            CounterV1 counter2 = new CounterV1("counter2", "source2", CounterTypeV1.Statistics, 5, 2, 2, 5, 3.5);
            counter2.Count = 1;

            await this._client.WriteCountersAsync(null, new CounterV1[] {counter1, counter2});

            var page = await this._client.ReadCountersAsync(null, FilterParams.FromTuples("name", "counter1"), null);
            Assert.Single(page.Data);

            var new_counter = page.Data[0];
            Assert.Equal(3, new_counter.Count);
            Assert.Equal(0, new_counter.Min);
            Assert.Equal(10, new_counter.Max);
            Assert.Equal(5, new_counter.Average);
        }
    }
}
