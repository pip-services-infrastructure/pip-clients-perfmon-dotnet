using PipServices.Perfmon.Client.Version1;
using PipServices3.Commons.Config;
using PipServices3.Commons.Data;
using System;

namespace run
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var correlationId = "123";
                var config = ConfigParams.FromTuples(
                    "connection.type", "http",
                    "connection.host", "localhost",
                    "connection.port", 8080
                );
                var client = new PerfMonHttpClientV1();
                client.Configure(config);
                CounterV1 counter1 = new CounterV1("counter1", "source1", CounterTypeV1.Statistics, 5, 2, 2, 5, 3.5);
                CounterV1 counter2 = new CounterV1("counter2", "source2", CounterTypeV1.Statistics, 5, 2, 2, 5, 3.5);
                client.OpenAsync(correlationId);
                //var counter = client.WriteCounterAsync(correlationId, counter1);
                client.WriteCountersAsync(null, new CounterV1[] { counter1, counter2 });
                var page = client.ReadCountersAsync(null, FilterParams.FromTuples("name", "counter1"), null);
                Console.WriteLine("Read counters: ");

                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();

                client.CloseAsync(string.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
