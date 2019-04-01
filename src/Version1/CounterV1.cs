using System;
using System.Runtime.Serialization;

namespace PipServices.Perfmon.Client.Version1
{
    [DataContract]
    public class CounterV1
    {
        public CounterV1() { }

        public CounterV1(string name, string source, int type, double last, int count, double min, double max, double average)
        {
            Name = name;
            Source = source;
            Type = type;
            Last = last;
            Count = count;
            Min = min;
            Max = max;
            Average = average;
            Time = DateTime.Now;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "source")]
        public string Source { get; set; }

        [DataMember(Name = "type")]
        public int Type { get; set; }

        [DataMember(Name = "last")]
        public double Last { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "min")]
        public double Min { get; set; }

        [DataMember(Name = "max")]
        public double Max { get; set; }

        [DataMember(Name = "average")]
        public double Average { get; set; }

        [DataMember(Name = "time")]
        public DateTime Time { get; set; }
    }
}
