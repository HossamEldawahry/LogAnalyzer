using LogAnalyzer.Counters;
using LogAnalyzer.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer.Core
{
    public class LogAnalyzer
    {
        private readonly ILogReader _reader;
        private readonly IIPCounter _counter;

        public LogAnalyzer(ILogReader reader, IIPCounter counter)
        {
            _reader = reader;
            _counter = counter;
        }

        public void Analyze()
        {
            Parallel.ForEach(
                _reader.ReadLines(),
                new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount },
                line =>
                {
                    var ip = ExtractIP(line);
                    if (ip != null)
                        _counter.Increment(ip);
                });
        }

        private static string? ExtractIP(string line)
        {
            var parts = line.Split(';');
            foreach (var part in parts)
            {
                if (part.StartsWith("ip="))
                    return part.Substring(3);
            }
            return null;
        }
    }
}
