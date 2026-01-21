using LogAnalyzer.Counters;
using LogAnalyzer.Output;
using LogAnalyzer.Readers;

string filePath = "server_logs.txt";

var reader = new FileLogReader(filePath);
var counter = new ConcurrentIPCounter();
var analyzer = new LogAnalyzer.Core.LogAnalyzer(reader, counter);

analyzer.Analyze();

ResultPrinter.PrintTop(counter, 5);