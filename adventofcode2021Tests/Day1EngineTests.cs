using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day1;

namespace adventofcode2021Tests
{
    public class Day1EngineTests
    {
        [Theory]
        [InlineData(7, 1, 199, 200, 208, 210, 200, 207, 240, 269, 260, 263)]
        [InlineData(0, 1, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1)]
        [InlineData(9, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        [InlineData(5, 3, 199, 200, 208, 210, 200, 207, 240, 269, 260, 263)]
        [InlineData(1, 3, 1, 1, 1, 2)]
        public void IncreaseCounter_CountsIncreases_In_DepthArray(int expectedValue, int slidingWindow, params int[] depths)
        {
            // Arrange
            var sut = new Day1Engine();
            int result;

            // Act
            sut.Execute(slidingWindow, depths, out result);

            // Assert
            result.Should().Be(expectedValue);
        }

    }
}
