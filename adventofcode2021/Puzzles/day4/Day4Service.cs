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

        public void Execute(string fileName = ".\\Puzzles\\Day1\\Input.txt")
        {
            var input = _fileReader.ReadData<string>(fileName);
            int result;
            // Task 1
            _engine.Execute(input, out result);
            Console.WriteLine($"Task 1 - Power consumption result: {result}.");

            //// Task 2
            _engine.Execute2(input, out result);
            Console.WriteLine($"Task 2 - Life Support Rating: {result}.");
        }
    }
}
