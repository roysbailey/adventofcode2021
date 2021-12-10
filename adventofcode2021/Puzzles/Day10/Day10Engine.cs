using System;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode2021.Puzzles.Day10
{
    public class Day10Engine : IDay10Engine
    {
        private readonly char[] chunkOpennings = new char[] { '(', '[', '{', '<' };
        private readonly char[] chunkClosures = new char[] { ')', ']', '}', '>' };
        private readonly IDictionary<char, char> chunkMatches = new Dictionary<char, char> { {'(', ')'}, { '[', ']' }, { '{', '}' }, { '<', '>' } };

        public void Part1(IEnumerable<string> navSubSystemLines, out long syntaxCheckScore)
        {
            var syntaxCheckScores = new List<long>();
            foreach (var line in navSubSystemLines)
                syntaxCheckScores.Add(SyntaxCheckLine(line));

            syntaxCheckScore = syntaxCheckScores.Sum();
        }

        public void Part2(IEnumerable<string> navSubSystemLines, out long totalValue)
        {
            var incompleteLineScores = new List<long>();
            navSubSystemLines.Where(l => SyntaxCheckLine(l) == 0).ToList()
                .ForEach(l => incompleteLineScores.Add(ScoreMissingLineEnd(CalculateMissingLineEnd(l))));

            var sortedScores = incompleteLineScores.OrderBy(a => a).ToList();
            totalValue = sortedScores[sortedScores.Count/2];
        }

        private long ScoreMissingLineEnd(string missingLineEnd)
        {
            long score = 0;
            var chunkEndScores = new Dictionary<char, int> { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };

            missingLineEnd.ToList().ForEach(ce => score = (score * 5) + chunkEndScores[ce]) ;
            return score;
        }

        private string CalculateMissingLineEnd(string line)
        {
            var chunkStartsToEnds = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
            var openChunks = new Stack<char>();

            foreach (var ch in line)
            {
                if (chunkOpennings.Contains(ch)) openChunks.Push(ch);
                if (chunkClosures.Contains(ch)) openChunks.Pop();
            }

            return new string(openChunks.Select(ch => chunkStartsToEnds[ch]).ToArray());
        }

        private long SyntaxCheckLine(string line)
        {
            var openChunks = new Stack<char>();
            var chunkEndScores = new Dictionary<char, int> { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };

            foreach (var ch in line)
            {
                if (chunkOpennings.Contains(ch)) openChunks.Push(ch);
                if (chunkClosures.Contains(ch))
                    if (openChunks.Count() == 0 || ch != chunkMatches[openChunks.Pop()])
                        return chunkEndScores[ch];
            }
            return 0;
        }
    }
}

