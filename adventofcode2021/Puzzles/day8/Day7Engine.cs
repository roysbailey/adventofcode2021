using adventofcode2021.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day7
{
    public class Day7Engine : IDay7Engine
    {
        public void Part1(IEnumerable<string> input, out int fuelCost)
        {
            int horPos;
            FindFuelCostOfCheapestHorizontalPos(input.First(), x=>x, out horPos, out fuelCost);
        }

        public void Part2(IEnumerable<string> input, out int fuelCost)
        {
            int horPos;
            FindFuelCostOfCheapestHorizontalPos(input.First(), x => x * (x + 1) / 2, out horPos, out fuelCost);
        }

        public void FindFuelCostOfCheapestHorizontalPos(string input, Func<int,int> fuelCostStrategy, out int horPos, out int fuelCost)
        {
            var crabStartPositions = input.Split(",").Select(int.Parse).ToList();

            var fuelsPerPosition = new Dictionary<int, int>();
            for (int i = crabStartPositions.Min(); i < crabStartPositions.Max(); i++)
            {
                var fuelsForStartPos = 0;
                crabStartPositions.ForEach(cp =>
                {
                    var fulesForMove = i - cp;
                    fuelsForStartPos += fuelCostStrategy(fulesForMove > 0 ? fulesForMove : fulesForMove * -1); 
                });
                fuelsPerPosition.Add(i, fuelsForStartPos);
            }

            horPos = fuelsPerPosition.OrderBy(di => di.Value).First().Key;
            fuelCost = fuelsPerPosition.OrderBy(di => di.Value).First().Value;
        }
    }
}
