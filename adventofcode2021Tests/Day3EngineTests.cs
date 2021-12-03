using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day3;

namespace adventofcode2021Tests
{
    public class Day3EngineTests
    {
        [Theory]
        [InlineData(10, "100", "101", "111")]
        [InlineData(198, "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010")]
        public void Calculates_Correct_PowerConsumption_From_Diagnostics(int expectedValue, params string[] diagnostics)
        {
            // Arrange
            var sut = new Day3Engine();
            int result;

            // Act
            sut.Execute(diagnostics, out result);

            // Assert
            result.Should().Be(expectedValue);
        }
            
        [Theory]
        [InlineData(230, "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010")]
        [InlineData(7, "100", "001", "111")]
        public void Calculates_Correct_LifeSupportRating_From_Diagnostics(int expectedValue, params string[] diagnostics)
        {
            // Arrange
            var sut = new Day3Engine();
            int result;

            // Act
            sut.Execute2(diagnostics, out result);

            // Assert
            result.Should().Be(expectedValue);
        }
    }
}
