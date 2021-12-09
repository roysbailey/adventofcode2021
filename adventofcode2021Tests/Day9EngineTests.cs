using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day9;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2021Tests
{
    public class Day9EngineTests
    {
        [Theory]
        [InlineData(15, "2199943210", "3987894921", "9856789892", "8767896789", "9899965678")]

        public void Can_Identify_LowPoint_vs_Adjacent_Sides(int expectedSum, params string[] gridRows)
        {
            // Arrange
            var sut = new Day9Engine();
            int actualSum;

            // Act
            sut.Part1(gridRows, out actualSum);

            // Assert
            actualSum.Should().Be(expectedSum);
        }

        [Theory]
        [InlineData(1134, "2199943210", "3987894921", "9856789892", "8767896789", "9899965678")]
        public void Can_Sum_Three_Largest_Basins(int expectedSum, params string[] gridRows)
        {
            // Arrange
            var sut = new Day9Engine();
            int actualSum;

            // Act
            sut.Part2(gridRows, out actualSum);

            // Assert
            actualSum.Should().Be(expectedSum);
        }

    }
}