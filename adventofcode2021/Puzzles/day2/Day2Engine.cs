using adventofcode2021.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day2
{
    public class Day2Engine : IDay2Engine
    {
        public void Execute(IEnumerable<string> input, out int result)
        {
            var instructions = input.Select(i => { var x = i.Split(" "); return new { Command = x[0], Value = int.Parse(x[1]) }; });

            var horPos = instructions.Where(x => x.Command == "forward").Sum(x => x.Value);
            var depth = instructions.Where(x => x.Command == "down").Sum(x => x.Value) - instructions.Where(x => x.Command == "up").Sum(x => x.Value);

            result = horPos * depth;
        }

        public void Execute2(IEnumerable<string> input, out int result)
        {
            var instructions = input.Select(i => { var x = i.Split(" "); return new { Command = x[0], Value = int.Parse(x[1]) }; });

            int depth = 0, aim = 0, horPos = 0;
            foreach (var ins in instructions)
            {
                switch (ins.Command)
                {
                    case "forward":
                        horPos += ins.Value;
                        depth += aim * ins.Value;
                        break;
                    case "up":
                        aim -= ins.Value;
                        break;
                    case "down":
                        aim += ins.Value;
                        break;
                }
            }

            result = horPos * depth;
        }

    }
}
