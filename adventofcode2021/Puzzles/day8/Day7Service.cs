using System;
using System.Diagnostics;
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
            int result;

            _engine.Part1(input, out result);
            Console.WriteLine($"Task 1 - Optimum horizontal col to minimise fuel : {result}.");

            _engine.Part2(input, out result);
            Console.WriteLine($"Task 2 - Optimum horizontal col to minimise fuel : {result}.");
        }
    }
}
