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

        public void Execute(string fileName = ".\\Puzzles\\Day5\\Input.txt")
        {
            var input = _fileReader.ReadData<string>(fileName);
            int result;
            // Task 1
            _engine.Execute(input, out result);
            Console.WriteLine($"Task 1 - score: {result}.");

            // Task 2
            //_engine.Execute2(input, out result);
            //Console.WriteLine($"Task 2 - score: {result}.");
        }
    }
}
