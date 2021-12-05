using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles
{
    public interface IDayEngine<T>
    {
        public void Part1(IEnumerable<T> input, out int output);
        public void Part2(IEnumerable<T> input, out int output);
    }
}
