using System.Threading.Tasks;
using PipServices.Perfmon.Client.Version1;
using PipServices3.Commons.Config;
using PipServices3.Commons.Refer;
using PipServices3.Commons.Run;
using PipServices3.Components.Count;
using PipServices3.Components.Info;
using PipServices3.Components.Log;

namespace PipServices.Perfmon.Client.Perfmon
{
    public abstract class AbstractPerfMon : CachedCounters, IReferenceable, IOpenable
    {
        protected IPerfMonClientV1 _client;
        protected string _source;

        public AbstractPerfMon(IPerfMonClientV1 client) : base()
        {
            _client = client;
        }

        public override void Configure(ConfigParams config)
        {
            base.Configure(config);
            this._source = config.GetAsStringWithDefault("source", this._source);
            (this._client as IConfigurable).Configure(config);
        }

        public void SetReferences(IReferences references)
        {
            (this._client as IReferenceable).SetReferences(references);
            (this._client as dynamic)._logger = new CompositeLogger();
            (this._client as dynamic)._counters = new CompositeCounters();
            ContextInfo contextInfo = references.GetOneOptional<ContextInfo>(
                new Descriptor("pip-services", "context-info", "default", "*", "1.0"));
            if (contextInfo != null && this._source == null)
                this._source = contextInfo.Name;
        }

        public bool IsOpen()
        {
            return (this._client as dynamic).IsOpened();
        }

        public Task OpenAsync(string correlationId)
        {
            return (this._client as dynamic).OpenAsync(correlationId);
        }

        public Task CloseAsync(string correlationId)
        {
            return (this._client as dynamic).CloseAsync(correlationId);
        }

        public void Save(CounterV1[] counters)
        {
            foreach (CounterV1 counter in counters)
            {
                counter.Source = counter.Source != null ? counter.Source 
                    : this._source != null ? this._source : "unknown";
            }
            this._client.WriteCountersAsync("counters", counters);
        }
    }
}
