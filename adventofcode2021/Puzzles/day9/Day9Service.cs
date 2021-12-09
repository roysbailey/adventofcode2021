using System;
using System.Diagnostics;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day9
{
    public class Day9Service : IDay9Service
    {
        IFileDataReader _fileReader = null;
        IDay9Engine _engine = null;

        public Day9Service(IFileDataReader fileReader, IDay9Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName)
        {
            var input = _fileReader.ReadData<string>(fileName);
            int result;

            _engine.Part1(input, out result);
            Console.WriteLine($"Task 1 - Lowest of adjascent score : {result}.");

            _engine.Part2(input, out result);
            Console.WriteLine($"Task 2 - Top 3 Basin value : {result}.");
        }
    }
}
