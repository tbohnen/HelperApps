using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISLogReader
{
    public interface ILogReader
    {
        List<LogEntry> LogEntries {get; }
        void AddFileToEntries(string fileName);
        List<string> Header { get; }
    }
}
