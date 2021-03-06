using System;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day4
{
    public class Day4Service : IDay4Service
    {
        IFileDataReader _fileReader = null;
        IDay4Engine _engine = null;

        public Day4Service(IFileDataReader fileReader, IDay4Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName)
        {
            var input = _fileReader.ReadData<string>(fileName);
            int result;

            _engine.Part1(input, out result);
            Console.WriteLine($"Task 1 - Winning Bingo Card score: {result}.");

            _engine.Part2(input, out result);
            Console.WriteLine($"Task 2 - Losing Bingo Card score: {result}.");
        }
    }
}
