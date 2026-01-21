using System;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer.Counters
{
    public interface IIPCounter
    {
        void Increment(string ip);
        Dictionary<string, long> Snapshot();
    }
}
