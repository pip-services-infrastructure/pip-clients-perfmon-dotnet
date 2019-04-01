using System.Collections.Generic;
using PipServices.Perfmon.Client.Version1;
using PipServices3.Components.Count;

namespace PipServices.Perfmon.Client.Perfmon
{
    public class HttpPerfMon : AbstractPerfMon
    {
        public HttpPerfMon() : base(new PerfMonHttpClientV1())
        {
        }

        protected override void Save(IEnumerable<Counter> counters)
        {
            throw new System.NotImplementedException();
        }
    }
}
