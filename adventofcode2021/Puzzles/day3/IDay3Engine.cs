using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day3
{
    public interface IDay3Engine
    {
        public void Execute(IEnumerable<string> input, out int result);
        public void Execute2(IEnumerable<string> input, out int result);
    }
}
