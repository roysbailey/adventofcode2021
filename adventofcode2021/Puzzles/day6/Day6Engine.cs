using adventofcode2021.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day6
{
    public class Day6Engine : IDay6Engine
    {
        private const int reproductionDaysAdult = 6;
        private const int reproductionDaysNewBornet = 8;

        public void Part1(IEnumerable<string> lanternFish, out long result)
        {
            result = SimulateLanternFishReproduction(lanternFish.First(), 80);
        }

        public void Part2(IEnumerable<string> lanternFish, out long result)
        {
            result = SimulateLanternFishReproduction(lanternFish.First(), 256);
        }

        public long SimulateLanternFishReproduction(string lanternFish, int daysToSimulate)
        {
            long[] fishCountByDaysToReproduce = { 0L, 0L, 0L, 0L, 0L, 0L, 0L, 0L, 0L };
            lanternFish.Split(",").Select(int.Parse).ToList().ForEach(fd => fishCountByDaysToReproduce[fd]++);

            for (int day = 0; day < daysToSimulate; day++)
            {
                var fishGivingBirthToday = fishCountByDaysToReproduce[0];
                for (int i = 1; i < reproductionDaysNewBornet+1; i++)
                    fishCountByDaysToReproduce[i - 1] = fishCountByDaysToReproduce[i];
                fishCountByDaysToReproduce[reproductionDaysNewBornet] = fishGivingBirthToday;
                fishCountByDaysToReproduce[reproductionDaysAdult] += fishGivingBirthToday;
            }

            return fishCountByDaysToReproduce.AsEnumerable().Sum();
        }

        // Original model based, naive implementation.
        //=============================================
        //public IEnumerable<int> SimulateLanternFish(string lanternFish, int days)
        //{
        //    var fishPopulation = lanternFish.Split(",").Select(d => new LanternFish(int.Parse(d))).ToList();
        //    for (int i = 0; i < days; i++)
        //    {
        //        LanternFish newFish;
        //        var newFishList = new List<LanternFish>();
        //        fishPopulation.ForEach(f => {if (f.NextDay(out newFish)) newFishList.Add(newFish); });
        //        fishPopulation.AddRange(newFishList);
        //    }

        //    return fishPopulation.Select(f => f.DaysTillReproduce);
        //}

        //internal class LanternFish
        //{
        //    private readonly int _defaultReproductionCycleDays = 6;
        //    private readonly int _newFishReproductionCycleDays = 8;

        //    internal int DaysTillReproduce { get; set; }

        //    internal LanternFish()
        //    {
        //        DaysTillReproduce = _defaultReproductionCycleDays;
        //    }

        //    internal LanternFish(int daysTillReproduce)
        //    {
        //        DaysTillReproduce = daysTillReproduce;
        //    }

        //    internal bool NextDay(out LanternFish offspring)
        //    {
        //        offspring = null;
        //        if (DaysTillReproduce == 0)
        //        {
        //            DaysTillReproduce = _defaultReproductionCycleDays;
        //            offspring = new LanternFish(_newFishReproductionCycleDays);
        //            return true;
        //        }

        //        DaysTillReproduce--;
        //        return false;
        //    }
        //}
    }
}
