using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day2;

namespace adventofcode2021Tests
{
    public class Day2EngineTests
    {
        [Theory]
        [InlineData(150, "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2")]
        [InlineData(50, "forward 5", "down 100", "forward 5", "up 98", "down 8", "forward -5")]
        public void Calculates_Correct_Sub_Position_From_Instructions(int expectedValue, params string[] instructions)
        {
            // Arrange
            var sut = new Day2Engine();
            int result;

            // Act
            sut.Part1(instructions, out result);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(900, "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2")]
        [InlineData(750, "forward 5", "down 5", "forward 5", "up 5", "down 5", "forward 5")]
        public void Calculates_Correct_Sub_Position_From_Instructions_And_Aim(int expectedValue, params string[] instructions)
        {
            // Arrange
            var sut = new Day2Engine();
            int result;

            // Act
            sut.Part2(instructions, out result);

            // Assert
            result.Should().Be(expectedValue);
        }
    }
}


