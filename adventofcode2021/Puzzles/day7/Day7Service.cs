using System;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day7
{
    public class Day7Service : IDay7Service
    {
        IFileDataReader _fileReader = null;
        IDay7Engine _engine = null;

        public Day7Service(IFileDataReader fileReader, IDay7Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName)
        {
            var input = _fileReader.ReadData<string>(fileName);
            long result;

            _engine.Part1(input, out result);
            Console.WriteLine($"Task 1 - Number of lantern fish after 80 days : {result}.");

            _engine.Part2(input, out result);
            Console.WriteLine($"Task 2 - Number of lantern fish after 256 days : {result}.");
        }
    }
}
