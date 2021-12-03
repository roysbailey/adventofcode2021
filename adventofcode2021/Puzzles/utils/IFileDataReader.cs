using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Utils
{
    public interface IFileDataReader
    {
        IEnumerable<T> ReadData<T>(string fileName);
    }
}
