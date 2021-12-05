using System;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day5
{
    public class Day5Service : IDay5Service
    {
        IFileDataReader _fileReader = null;
        IDay5Engine _engine = null;

        public Day5Service(IFileDataReader fileReader, IDay5Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName)
        {
            var input = _fileReader.ReadData<string>(fileName);
            int result;

            _engine.Part1(input, out result);
            Console.WriteLine($"Task 1 - Count of overlap points for straight lines: {result}.");

            _engine.Part2(input, out result);
            Console.WriteLine($"Task 2 - Count of overlap points for ALL lines: {result}.");
        }
    }
}
