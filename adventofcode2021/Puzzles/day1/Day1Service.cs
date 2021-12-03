using System;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day1
{
    public class Day1Service : IDay1Service
    {
        IFileDataReader _fileReader = null;
        IDay1Engine _engine = null;

        public Day1Service(IFileDataReader fileReader, IDay1Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day1\\Input.txt")
        {
            var depths = _fileReader.ReadData<int>(fileName);
            int increaseCount;
            // Task 1
            _engine.Execute(1, depths, out increaseCount);
            Console.WriteLine($"Task 1 - there were {increaseCount} increases in depths provided.");
            // Task 2
            _engine.Execute(3, depths, out increaseCount);
            Console.WriteLine($"Task 2 - there were {increaseCount} increases in depths provided.");
        }
    }
}
