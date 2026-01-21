using System;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer.Readers
{
    public interface ILogReader
    {
        IEnumerable<string> ReadLines();
    }
}
