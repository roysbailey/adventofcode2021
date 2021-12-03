using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day4
{
    public interface IDay4Engine
    {
        public void Execute(IEnumerable<string> input, out int result);
        public void Execute2(IEnumerable<string> input, out int result);
    }
}
