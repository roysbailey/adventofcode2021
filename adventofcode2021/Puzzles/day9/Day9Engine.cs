using System.Linq;
using System.Collections.Generic;

namespace adventofcode2021.Puzzles.Day9
{
    public class Day9Engine : IDay9Engine
    {
        private int[][] gridArray;

        public void Part1(IEnumerable<string> gridLines, out int sumOfLowPointRisks)
        {
            GridLinesToArray(gridLines);
            sumOfLowPointRisks = FindLowPointCoords().Select(p => gridArray[p.Y][p.X] + 1).Sum();
        }

        public void Part2(IEnumerable<string> gridLines, out int totalValue)
        {
            GridLinesToArray(gridLines);
            var lowPointCoords = FindLowPointCoords();

            var basins = new List<List<PointWithValue>>();
            foreach (var lowPointCoord in lowPointCoords)
            {
                var basinList = new List<PointWithValue>();
                basinList.Add(new PointWithValue(lowPointCoord.X, lowPointCoord.Y, gridArray[lowPointCoord.Y][lowPointCoord.X]));
                fillBasin(lowPointCoord, basinList);
                basins.Add(basinList);
            }

            totalValue = basins.OrderByDescending(b => b.Count()).Take(3).Select(b => b.Count()).Aggregate((x, y) => x * y);
        }

        private IEnumerable<Point> FindLowPointCoords()
        {
            return Enumerable.Range(0, gridArray.GetLength(0))
                             .SelectMany(
                                 y =>
                                 Enumerable.Range(0, gridArray[0].GetLength(0)).Select(x => GetAdjascentGridCells(x, y).Where(ac => ac.Val <= gridArray[y][x]).Count() == 0 ? new Point(x, y) : null).Where(v => v != null));
        }

        void GridLinesToArray(IEnumerable<string> gridLines)
        {
            gridArray = gridLines.ToArray().Select(s => s.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
        }

        private IEnumerable<PointWithValue> GetAdjascentGridCells(int x, int y)
        {
            var adjCells = new List<PointWithValue>();
            if (x > 0)
                adjCells.Add(new PointWithValue(x-1, y, gridArray[y][x - 1]));
            if (x < gridArray[0].GetLength(0)-1)
                adjCells.Add(new PointWithValue(x+1, y, gridArray[y][x + 1]));
            if (y > 0)
                adjCells.Add(new PointWithValue(x, y-1, gridArray[y - 1][x]));
            if (y < gridArray.GetLength(0)-1)
                adjCells.Add(new PointWithValue(x, y+1, gridArray[y + 1][x]));

            return adjCells;
        }

        private void fillBasin(Point pointCoords, List<PointWithValue> set)
        {
            var basinFlowsFromPoint = GetAdjascentGridCells(pointCoords.X, pointCoords.Y).Where(pv => pv.Val != 9 && pv.Val > gridArray[pointCoords.Y][pointCoords.X]);
            set.AddRange(basinFlowsFromPoint.Where(bf => !set.Any(s => s.CellPoint.X == bf.CellPoint.X && s.CellPoint.Y == bf.CellPoint.Y)));
            foreach (var basinPoint in basinFlowsFromPoint)
                fillBasin(basinPoint.CellPoint, set);
        }

        internal class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        internal class PointWithValue
        {
            public Point CellPoint { get; }
            public int Val { get; set; }
            public PointWithValue(int x, int y, int val)
            {
                CellPoint = new Point(x,y);
                Val = val;
            }
        }
    }
}