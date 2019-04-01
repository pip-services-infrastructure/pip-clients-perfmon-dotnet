using PipServices.Perfmon.Client.Perfmon;
using PipServices.Perfmon.Client.Version1;
using PipServices3.Commons.Refer;
using PipServices3.Components.Build;

namespace PipServices.Perfmon.Client.Build
{
    public class PerfMonClientFactory : Factory
    {
        public static Descriptor Descriptor = new Descriptor("pip-services-perfmon", "factory", "default", "default", "1.0");
        public static Descriptor HttpPerfMonDescriptor = new Descriptor("pip-services-perfmon", "counters", "http", "default", "1.0");
        public static Descriptor NullClientDescriptor = new Descriptor("pip-services-perfmon", "client", "null", "*", "1.0");
        public static Descriptor HttpClientDescriptor = new Descriptor("pip-services-perfmon", "client", "http", "*", "1.0");

        public PerfMonClientFactory()
        {
            RegisterAsType(NullClientDescriptor, typeof(PerfMonNullClientV1));
            RegisterAsType(HttpClientDescriptor, typeof(PerfMonHttpClientV1));
            RegisterAsType(HttpPerfMonDescriptor, typeof(HttpPerfMon));
        }
    }
}
