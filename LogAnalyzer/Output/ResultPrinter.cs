using LogAnalyzer.Counters;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer.Output
{
    public static class ResultPrinter
    {
        public static void PrintTop(IIPCounter counter, int top)
        {
            var snapshot = counter.Snapshot();

            var topIps = snapshot
                .OrderByDescending(x => x.Value)
                .Take(top);

            Console.WriteLine("Top IP Addresses:");
            foreach (var item in topIps)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
