using System;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer.Readers
{
    internal class FileLogReader : ILogReader
    {
        private readonly string _filePath;

        public FileLogReader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<string> ReadLines()
        {
            using var stream = new FileStream(
                _filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 1024 * 1024);

            using var reader = new StreamReader(stream);

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
