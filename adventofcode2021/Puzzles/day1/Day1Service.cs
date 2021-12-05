using System;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day1
{
    public class Day1Service : IDay1Service
    {
        IFileDataReader _fileReader = null;
        IDay1Engine _engine = null;

        public Day1Service(IFileDataReader fileReader, IDay1Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName)
        {
            var depths = _fileReader.ReadData<int>(fileName);
            int increaseCount;

            _engine.Part1(depths, out increaseCount);
            Console.WriteLine($"Task 1 - there were {increaseCount} increases in depths provided.");

            _engine.Part2(depths, out increaseCount);
            Console.WriteLine($"Task 2 - there were {increaseCount} increases in depths provided.");
        }
    }
}
