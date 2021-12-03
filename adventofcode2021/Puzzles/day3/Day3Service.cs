using System;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day3
{
    public class Day3Service : IDay3Service
    {
        IFileDataReader _fileReader = null;
        IDay3Engine _engine = null;

        public Day3Service(IFileDataReader fileReader, IDay3Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day3\\Input.txt")
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
