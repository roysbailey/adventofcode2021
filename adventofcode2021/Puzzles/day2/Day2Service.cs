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

        public void Execute(string fileName)
        {
            var input = _fileReader.ReadData<string>(fileName);
            int result;

            _engine.Part1(input, out result);
            Console.WriteLine($"Task 1 - Position calculation result: {result}.");

            _engine.Part2(input, out result);
            Console.WriteLine($"Task 2 - Position calculation on aim result: {result}.");
        }
    }
}
