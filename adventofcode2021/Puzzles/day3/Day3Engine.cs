using adventofcode2021.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day3
{
    public class Day3Engine : IDay3Engine
    {
        public void Execute(IEnumerable<string> diagnostics, out int result)
        {
            int gammaRate = 0, epsilonRate = 0, numBits = diagnostics.First().Length;
            for (int bitOffset = 0; bitOffset < numBits; bitOffset++)
            {
                var bitCountByValue = diagnostics
                    .Select(d => int.Parse(d[bitOffset].ToString()))
                        .GroupBy(v => v).Select(g => new { Key = g.Key, Cnt = g.Count() })
                            .OrderByDescending(go => go.Cnt).Select(go=>go.Key).ToList();

                gammaRate += (int)Math.Pow(2, numBits-bitOffset-1) * bitCountByValue[0];
                epsilonRate += bitCountByValue.Count > 1 ? (int)Math.Pow(2, numBits - bitOffset - 1) * bitCountByValue[1] : 0;
            }

            result = gammaRate * epsilonRate;
        }

        public void Execute2(IEnumerable<string> diagnostics, out int result)
        {
            var oxyGenRating = FindDiagRowValueForRating(diagnostics, 0, v => v);
            var co2ScrubberRating = FindDiagRowValueForRating(diagnostics, 0, v => v == 1 ? 0 : 1);

            result = oxyGenRating * co2ScrubberRating;
        }

        private int FindDiagRowValueForRating(IEnumerable<string> diagnostics, int bitOffset, Func<int, int> strategy)
        {
            var maxOccuringBitValue = diagnostics
                .Select(d => int.Parse(d[bitOffset].ToString()))
                    .GroupBy(v => v).Select(g => new { Key = g.Key, Cnt = g.Count() })
                        .OrderByDescending(go => go.Cnt).ThenByDescending(go => go.Key).FirstOrDefault().Key;

            var matchingRows = diagnostics.Where(d => int.Parse(d[bitOffset].ToString()) == strategy(maxOccuringBitValue)).ToList();

            if (matchingRows.Count == 0) throw new Exception("No matching rows for strategy");

            return matchingRows.Count == 1
                ? Convert.ToInt32(matchingRows.First(), 2)
                : FindDiagRowValueForRating(matchingRows, bitOffset + 1, strategy);
        }

        //private int FindDiagRowValueForRating(IEnumerable<string> diagnostics, int bitOffset, Func<int, int> strategy)
        //{
        //    var maxOccuringBitValue = diagnostics
        //        .Select(d => int.Parse(d[bitOffset].ToString()))
        //            .GroupBy(v => v).Select(g => new { Key = g.Key, Cnt = g.Count() })
        //                .OrderByDescending(go => go.Cnt).ThenByDescending(go => go.Key).FirstOrDefault().Key;

        //    var bitValueToMatch = strategy(maxOccuringBitValue);

        //    var matchingRows = diagnostics.Where(d => int.Parse(d[bitOffset].ToString()) == bitValueToMatch).ToList();

        //    if (matchingRows.Count == 0) throw new Exception("No matching rows for strategy");

        //    return matchingRows.Count == 1
        //        ? Convert.ToInt32(matchingRows.First(), 2)
        //        : FindDiagRowValueForRating(matchingRows, bitOffset + 1, strategy);
        //}
    }
}
