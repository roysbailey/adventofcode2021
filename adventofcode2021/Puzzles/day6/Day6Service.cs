using System;
using System.Diagnostics;
using System.Threading;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day6
{
    public class Day6Service : IDay6Service
    {
        IFileDataReader _fileReader = null;
        IDay6Engine _engine = null;

        public Day6Service(IFileDataReader fileReader, IDay6Engine engine)
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
