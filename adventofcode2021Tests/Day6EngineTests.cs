using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day6;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2021Tests
{
    public class Day6EngineTests
    {
        [Theory]
        [InlineData(2, "96,897 -> 984,897", "88,897 -> 984,332", "96,333 -> 96,897")]
        public void TestSomething(int expectedValue, params string[] input)
        {
            // Arrange
            var sut = new Day6Engine();
            int result;

            // Act
            sut.Part2(input, out result);

            // Assert
            result.Should().Be(expectedValue);
        }
    }
}