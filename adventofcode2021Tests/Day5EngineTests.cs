using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day5;


namespace adventofcode2021Tests
{
    public class Day5EngineTests
    {
        [Theory]
        [InlineData(90, "1,2,3", "", " 1  2  3", " 5  5  5", " 5  5  5")]
        public void Find_Winning_BingoCard(int expectedValue, params string[] input)
        {
            // Arrange
            var sut = new Day5Engine();
            int result;

            // Act
            sut.Execute(input, out result);

            // Assert
            result.Should().Be(expectedValue);
        }
    }
}
