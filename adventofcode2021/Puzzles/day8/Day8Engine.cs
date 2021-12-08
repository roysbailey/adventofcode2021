using adventofcode2021.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day8
{
    public class Day8Engine : IDay8Engine
    {
        public void Part1(IEnumerable<string> signalPatterns, out int countOfSimpleNumbers)
        {
            int[] simpleNumberSegmentCounts = { 2, 4, 3, 7 };

            countOfSimpleNumbers = signalPatterns.SelectMany(sp => sp.Split(" | ")[1].Split(" ").Select(s => s.Length)
                    .Where(sp => simpleNumberSegmentCounts.Contains(sp))).Count();
        }

        public void Part2(IEnumerable<string> signalPatterns, out int totalValue)
        {
            totalValue = 0;
            int overallValue = 0;
            signalPatterns.ToList().ForEach(d =>
            {
                var uniquePatterns = d.Split(" | ")[0].Split(" ").ToList();
                var outputDigits = d.Split(" | ")[1].Split(" ").ToList();

                var codesToNumbers = new Dictionary<int, string>();
                var fiveDigitPatterns = new List<string>();
                var sixDigitPatterns = new List<string>();
                uniquePatterns.ForEach(s =>
                {
                    var length = s.Length;
                    if (length == 2)
                        codesToNumbers[1] = s;
                    else if (length == 7)
                        codesToNumbers[8] = s;
                    else if (length == 3)
                        codesToNumbers[7] = s;
                    else if (length == 4)
                        codesToNumbers[4] = s;
                    else if (length == 5)
                        fiveDigitPatterns.Add(s);
                    else if (length == 6)
                        sixDigitPatterns.Add(s);
                });

                foreach (var val in sixDigitPatterns)
                {
                    if (codesToNumbers[4].Except(val).Count() == 0)
                        codesToNumbers[9] = val;
                    else if (codesToNumbers[1].Except(val).Count() == 1)
                        codesToNumbers[6] = val;
                    else
                        codesToNumbers[0] = val;
                }

                foreach (var val in fiveDigitPatterns)
                {
                    if (codesToNumbers[1].Except(val).Count() == 0)
                        codesToNumbers[3] = val;
                    else if (codesToNumbers[4].Except(val).Count() == 2)
                        codesToNumbers[2] = val;
                    else
                        codesToNumbers[5] = val;
                }

                string decodedNumberAsString = string.Empty;
                outputDigits.ForEach(od =>
                {
                    foreach (var n in codesToNumbers)
                        if (String.Concat(n.Value.OrderBy(c => c)) == String.Concat(od.OrderBy(c => c)))
                            decodedNumberAsString += n.Key.ToString();
                });
                overallValue += int.Parse(decodedNumberAsString);
            });
            totalValue = overallValue;
        }
    }
}
