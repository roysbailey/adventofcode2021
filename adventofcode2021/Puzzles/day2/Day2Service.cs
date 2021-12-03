using System;
using adventofcode2021.Puzzles.Utils;

namespace adventofcode2021.Puzzles.Day2
{
    public class Day2Service : IDay2Service
    {
        IFileDataReader _fileReader = null;
        IDay2Engine _engine = null;

        public Day2Service(IFileDataReader fileReader, IDay2Engine engine)
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
            Console.WriteLine($"Task 1 - Position calculation result: {result}.");

            // Task 2
            _engine.Execute2(input, out result);
            Console.WriteLine($"Task 2 - Position calculation on aim result: {result}.");
        }
    }
}
