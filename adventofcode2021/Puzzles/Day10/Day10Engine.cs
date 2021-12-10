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

        public void Part1(IEnumerable<string> navSubSystemLines, out int sumValidationErrors)
        {
            var openChunks = new Stack<char>();
            var syntaxErrors = new List<char>();

            //var completeLines = navSubSystemLines
            //    .Where(l =>
            //        l.Count(c => chunkOpennings.Contains(c)) == l.Count(c => chunkClosures.Contains(c))
            //        );

            foreach (var line in navSubSystemLines)
            {
                foreach (var ch in line)
                {
                    if (chunkOpennings.Contains(ch)) openChunks.Push(ch);
                    if (chunkClosures.Contains(ch))
                    {
                        if (openChunks.Count() == 0 || ch != chunkMatches[openChunks.Pop()])
                        {
                            syntaxErrors.Add(ch);
                            break;
                        }
                    }
                }
            }

            sumValidationErrors = 
                syntaxErrors.Count(se => se ==')') * 3 
                + syntaxErrors.Count(se => se == ']') * 57 
                + syntaxErrors.Count(se => se == '}') * 1197 
                + syntaxErrors.Count(se => se == '>') * 25137;
        }

        public void Part2(IEnumerable<string> gridLines, out int totalValue)
        {
            throw new NotImplementedException();
        }
   }
}