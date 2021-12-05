using adventofcode2021.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day5
{
    public class Day5Engine : IDay5Engine
    {
        public void Part1(IEnumerable<string> lineCoords, out int result)
        {
            result = PlotLines(lineCoords.Where(lc => IsStraightLine(lc))).Values.Where(v => v > 1).Count();
        }

        public void Part2(IEnumerable<string> lineCoords, out int result)
        {
            result = PlotLines(lineCoords).Values.Where(v => v > 1).Count();
        }

        public IDictionary<string, int> PlotLines(IEnumerable<string> lineCoords)
        {
            IDictionary<string, int> plottedPoints = new Dictionary<string, int>();

            lineCoords.ToList()
                .ForEach(ln => GeneratePointsForLineCoords(ln).ToList()
                    .ForEach(pt => { if (plottedPoints.ContainsKey(pt)) plottedPoints[pt] += 1; else plottedPoints.Add(pt, 1); }));
            
            return plottedPoints;
        }

        public IEnumerable<string> GeneratePointsForLineCoords(string lineCoords)
        {
            int[] startCoords, endCoords;
            ParseLineCoords(lineCoords, out startCoords, out endCoords);
            IEnumerable<string> pointsInLine;

            if (IsStraightLine(lineCoords))
            {
                if (startCoords[0] == endCoords[0])
                    pointsInLine = Enumerable.Range(Math.Min(startCoords[1], endCoords[1]), Math.Max(startCoords[1], endCoords[1]) - Math.Min(startCoords[1], endCoords[1]) + 1).Select(y => $"{startCoords[0]},{y}");
                else
                    pointsInLine = Enumerable.Range(Math.Min(startCoords[0], endCoords[0]), Math.Max(startCoords[0], endCoords[0]) - Math.Min(startCoords[0], endCoords[0]) + 1).Select(x => $"{x},{startCoords[1]}");
            }
            else
            {
                if (startCoords[0] > endCoords[0])
                {
                    var tmpCoord = startCoords;
                    startCoords = endCoords;
                    endCoords = tmpCoord;
                }
                var yInc = endCoords[1] > startCoords[1] ? +1 : -1;
                List<string> tmpPointsInLine = new List<string>();
                for (int i = 0; i < endCoords[0]-startCoords[0]+1; i++)
                    tmpPointsInLine.Add($"{startCoords[0]+i},{startCoords[1]+(i*yInc)}");
                pointsInLine = tmpPointsInLine.AsEnumerable();
            }

            return pointsInLine;
        }

        private static void ParseLineCoords(string c, out int[] startCoords, out int[] endCoords)
        {
            var coordPair = c.Split(" -> ");
            startCoords = coordPair[0].Split(",").Select(int.Parse).ToArray();
            endCoords = coordPair[1].Split(",").Select(int.Parse).ToArray();
        }

        public static bool IsStraightLine(string lineCoords)
        {
            int[] startCoords, endCoords;
            ParseLineCoords(lineCoords, out startCoords, out endCoords);
            return startCoords[0] == endCoords[0] || startCoords[1] == endCoords[1];
        }
    }
}
