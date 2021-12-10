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
        public void Can_Validate_Matching_Braces(int expectedSum, params string[] navSubSystemLines)
        {
            // Arrange
            var sut = new Day10Engine();
            int actualSum;

            // Act
            sut.Part1(navSubSystemLines, out actualSum);

            // Assert
            actualSum.Should().Be(expectedSum);
        }
    }
}

