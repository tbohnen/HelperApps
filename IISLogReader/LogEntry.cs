using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace IISLogReader
{
    public class LogEntry : DynamicObject
    {
        private Dictionary<string, string> _fields = new Dictionary<string,string>();

        public string this[string key]
        {
            get { return _fields[key]; }
        }
        
        public LogEntry(string[] values, IEnumerable<string> header)
        {
            for (int i = 0; i < header.Count(); i++)
            {
                _fields.Add(header.ToArray()[i], values[i]);
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var fieldExists = _fields.Any(header => header.Key == binder.Name);
            if (fieldExists)
                result = _fields[binder.Name];
            else
                result = null;

            return fieldExists;
        }
    }
}
