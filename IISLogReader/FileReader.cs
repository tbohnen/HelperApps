using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IISLogReader
{
    public class FileReader : IFileReader
    {

        public string[] ReadAllLines(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
