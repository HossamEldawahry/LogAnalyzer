using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer.Counters
{
    internal class ConcurrentIPCounter : IIPCounter
    {
        private readonly ConcurrentDictionary<string, long> _counts = new();

        public void Increment(string ip)
        {
            _counts.AddOrUpdate(ip, 1, (_, old) => old + 1);
        }

        public Dictionary<string, long> Snapshot()
        {
            return new Dictionary<string, long>(_counts);
        }
    }
}
