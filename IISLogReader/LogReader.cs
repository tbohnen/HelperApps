using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISLogReader
{
    public class LogReader : ILogReader
    {

        private IFileReader _fileReader;

        private List<string[]> _lines = new List<string[]>();
        private string[] _infoLines = new[] { "#Version:", "#Date:", "#Software:", "#Fields:" };


        public LogReader()
        {
            _fileReader = new FileReader();
        }
        public LogReader(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public List<LogEntry> LogEntries
        {
            get { 
                return _lines
                    .Where(line => IsLogEntry(line))
                    .Select(logEntryLine => new LogEntry(logEntryLine, Header))
                    .ToList(); 
            }
        }

        private bool IsLogEntry(string[] line)
        {
            return !_infoLines.Contains(line.First());
        }

        public void AddFileToEntries(string fileName)
        {
            var newLines = _fileReader.ReadAllLines(fileName)
                .Select(line => line.Split(' '))
                .ToList();

            _lines.AddRange(newLines);
        }

        public List<string> Header 
        { 
            get 
            {
                return _lines
                    .FirstOrDefault(l => l.First()
                        .Contains("#Fields"))
                        .Skip(1)
                        .Select(field => field.Replace("-",""))
                        .ToList();
            }
        }
    }
}
