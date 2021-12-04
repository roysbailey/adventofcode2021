using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day5
{
    public interface IDay5Engine
    {
        public void Execute(IEnumerable<string> input, out int result);
        public void Execute2(IEnumerable<string> input, out int result);
    }
}
