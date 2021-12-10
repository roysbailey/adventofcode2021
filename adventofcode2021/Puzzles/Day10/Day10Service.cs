using System;
using System.Diagnostics;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day10
{
    public class Day10Service : IDay10Service
    {
        IFileDataReader _fileReader = null;
        IDay10Engine _engine = null;

        public Day10Service(IFileDataReader fileReader, IDay10Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName)
        {
            var input = _fileReader.ReadData<string>(fileName);
            int result;

            _engine.Part1(input, out result);
            Console.WriteLine($"Task 1 - Syntax error value : {result}.");

            //_engine.Part2(input, out result);
            //Console.WriteLine($"Task 2 - Top 3 Basin value : {result}.");
        }
    }
}
