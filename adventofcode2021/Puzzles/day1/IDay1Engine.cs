using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day1
{
    public interface IDay1Engine
    {
        public void Execute(int rollingMeasureCount, IEnumerable<int> depths, out int countOfIncreases);
    }
}
