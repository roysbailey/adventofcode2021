using System;
using System.Diagnostics;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day8
{
    public class Day8Service : IDay8Service
    {
        IFileDataReader _fileReader = null;
        IDay8Engine _engine = null;

        public Day8Service(IFileDataReader fileReader, IDay8Engine engine)
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

            //_engine.Part2(input, out result);
            //Console.WriteLine($"Task 2 - Optimum horizontal col to minimise fuel : {result}.");
        }
    }
}
