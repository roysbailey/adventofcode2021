using FluentAssertions;
using Xunit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using adventofcode2021.Puzzles.Day10;

namespace adventofcode2021Tests
{
    public class Day10EngineTests
    {
        [Theory]
        [InlineData(1197, "{([(<{}[<>[]}>{[]{[(<()>")]
        [InlineData(3, "[[<[([]))<([[{}[[()]]]")]
        [InlineData(57, "[{[{({}]{}}([{[{{{}}([]")]
        [InlineData(3, "[<(<(<(<{}))><([]([]()")]
        [InlineData(25137, "<{([([[(<>()){}]>(<<{{")]
        [InlineData(26397, "{([(<{}[<>[]}>{[]{[(<()>", "[[<[([]))<([[{}[[()]]]", "[{[{({}]{}}([{[{{{}}([]", "[<(<(<(<{}))><([]([]()", "<{([([[(<>()){}]>(<<{{")]
        [InlineData(26397, "[({(<(())[]>[[{[]{<()<>>", "[(()[<>])]({[<{<<[]>>(", "{([(<{}[<>[]}>{[]{[(<()>", "(((({<>}<{<{<>}{[]{[]{}", "[[<[([]))<([[{}[[()]]]", "[{[{({}]{}}([{[{{{}}([]", "{<[[]]>}<{[{[{[]{()[[[]", "[<(<(<(<{}))><([]([]()", "<{([([[(<>()){}]>(<<{{", "<{([{{}}[<[[[<>{}]]]>[]]")]
        public void Can_Validate_Matching_Braces(long expectedSum, params string[] navSubSystemLines)
        {
            // Arrange
            var sut = new Day10Engine();
            long actualSum;

            // Act
            sut.Part1(navSubSystemLines, out actualSum);

            // Assert
            actualSum.Should().Be(expectedSum);
        }

        // full test - failed with: 237311081
        [Theory]
        [InlineData(288957, "[({(<(())[]>[[{[]{<()<>>", "[(()[<>])]({[<{<<[]>>(", "{([(<{}[<>[]}>{[]{[(<()>", "(((({<>}<{<{<>}{[]{[]{}", "[[<[([]))<([[{}[[()]]]", "[{[{({}]{}}([{[{{{}}([]", "{<[[]]>}<{[{[{[]{()[[[]", "[<(<(<(<{}))><([]([]()", "<{([([[(<>()){}]>(<<{{", "<{([{{}}[<[[[<>{}]]]>[]]")]
        [InlineData(995444, "[(()[<>])]({[<{<<[]>>(", "{([(<{}[<>[]}>{[]{[(<()>", "(((({<>}<{<{<>}{[]{[]{}", "[[<[([]))<([[{}[[()]]]", "[{[{({}]{}}([{[{{{}}([]", "{<[[]]>}<{[{[{[]{()[[[]", "[<(<(<(<{}))><([]([]()", "<{([([[(<>()){}]>(<<{{")]
        public void Can_Find_MiddleScore_Of_Incomplete_Line_Scores(long expectedSum, params string[] navSubSystemLines)
        {
            // Arrange
            var sut = new Day10Engine();
            long actualSum;

            // Act
            sut.Part2(navSubSystemLines, out actualSum);

            // Assert
            actualSum.Should().Be(expectedSum);
        }
    }
}

