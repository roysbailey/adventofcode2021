using adventofcode2021.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2021.Puzzles.Day4
{
    public class Day4Engine : IDay4Engine
    {
        public void Execute(IEnumerable<string> bingoInput, out int result)
        {
            IEnumerable<int> bingoNumbers;
            IEnumerable<BingoCard> bingoCards;
            ParseBingoInput(bingoInput, out bingoNumbers, out bingoCards);

            result = PlayBingo(bingoNumbers, bingoCards, () => true);
        }

        public void Execute2(IEnumerable<string> bingoInput, out int result)
        {
            IEnumerable<int> bingoNumbers;
            IEnumerable<BingoCard> bingoCards;
            ParseBingoInput(bingoInput, out bingoNumbers, out bingoCards);

            result = PlayBingo(bingoNumbers, bingoCards, () => bingoCards.Count(bc => bc.IsWinner) == bingoCards.Count());
        }

        private int PlayBingo(IEnumerable<int> bingoNumbers, IEnumerable<BingoCard> bingoCards, Func<bool> strategy)
        {
            foreach (var number in bingoNumbers)
            {
                foreach (var card in bingoCards)
                    if (card.MarkNumber(number))
                        if (strategy())
                            return card.FinalScore(number);
            }

            return 0;
        }

        private void ParseBingoInput(IEnumerable<string> bingoInput, out IEnumerable<int> bingoNumbers, out IEnumerable<BingoCard> bingoCards)
        {
            bingoNumbers = bingoInput.First().Split(",").Select(bn => int.Parse(bn));

            bingoCards = bingoInput.Skip(2).Select((p, index) => new { p, index })
                .GroupBy(a => a.index / 6)
                .Select((grp => grp.Select(g => g.p).ToList()))
                .ToList().Select(c => new BingoCard(c)).ToList();
        }

        class BingoCard
        {
            private List<List<int>> cardRows = new List<List<int>>();
            private readonly int markedValue = -1;
            internal BingoCard(IEnumerable<string> rows)
            {
                foreach (var row in rows.Where(r=>r.Length>0))
                {
                    var rowVal = row.Split(" ").Where(rv=>!String.IsNullOrWhiteSpace(rv)).Select(rv => int.Parse(rv)).ToList();
                    cardRows.Add(rowVal);
                }
            }

            internal bool MarkNumber(int number)
            {
                foreach (var row in cardRows)
                    if (row.Contains(number))
                        for (int i = 0; i < row.Count; i++)
                            if (row[i] == number) row[i] = markedValue;

                return IsWinner;
            }

            internal int FinalScore(int number)
            {
                var unmarkedCardValue = cardRows.Sum(r => r.Where(v => v != markedValue).Sum());

                return unmarkedCardValue * number;
            }

            public bool IsWinner 
            { 
                get
                {
                    if (cardRows.Where(cr => cr.Count(crv => crv != markedValue) == 0).Count() > 0) return true;

                    for (int col = 0; col < cardRows.First().Count; col++)
                        if (cardRows.Select(cr => cr[col]).Where(ccv => ccv != markedValue).Count() == 0) return true;

                    return false;
                }
            }
        }
    }
}
