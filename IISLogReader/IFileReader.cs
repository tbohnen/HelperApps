using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISLogReader
{
    public interface IFileReader
    {
        string[] ReadAllLines(string fileName);
    }
}
