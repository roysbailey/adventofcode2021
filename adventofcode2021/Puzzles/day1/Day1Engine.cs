using adventofcode2021.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day1
{
    public class Day1Engine : IDay1Engine
    {
        public void Execute(int rollingMeasureCount, IEnumerable<int> depths, out int countOfIncreases)
        {
            var depthList = depths.ToList();
            var depthRollingTotals = depths.Take(depthList.Count + 1 - rollingMeasureCount)
                .Select((depth, offset) => depthList.Skip(offset).Take(rollingMeasureCount).Sum());

            int lastDepth = int.MaxValue;
            countOfIncreases = 0;
            foreach (var depth in depthRollingTotals)
            {
                countOfIncreases += depth > lastDepth ? 1 : 0;
                lastDepth = depth;
            }
        }
    }
}
