using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day4;

namespace adventofcode2021Tests
{
    public class Day4EngineTests
    {
        [Theory]
        [InlineData(10, "100", "101", "111")]
        [InlineData(198, "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010")]
        public void DoSomething(int expectedValue, params string[] diagnostics)
        {
            // Arrange
            var sut = new Day4Engine();
            int result;

            // Act
            sut.Execute(diagnostics, out result);

            // Assert
            result.Should().Be(expectedValue);
        }
    }
}
