using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day7;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2021Tests
{
    public class Day7EngineTests
    {
        [Theory]
        [InlineData(37, "16,1,2,0,4,2,7,1,2,14")]
        public void Works_Out_Horizontal_Alignment_Pos_With_Least_Moves(int expectedFuelUsed, params string[] horizontalPositions)
        {
            // Arrange
            var sut = new Day7Engine();
            int actualFuelUsed;

            // Act
            sut.Part1(horizontalPositions, out actualFuelUsed);

            // Assert
            expectedFuelUsed.Should().Be(actualFuelUsed);
        }

        [Theory]
        [InlineData(168, "16,1,2,0,4,2,7,1,2,14")]
        public void Works_Out_Horizontal_Alignment_Pos_With_Least_Moves_2(int expectedFuelUsed, params string[] horizontalPositions)
        {
            // Arrange
            var sut = new Day7Engine();
            int actualFuelUsed;

            // Act
            sut.Part2(horizontalPositions, out actualFuelUsed);

            // Assert
            expectedFuelUsed.Should().Be(actualFuelUsed);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        public void Works_Out_FuelCost_Of_ExpensiveFuel(int moveDistance, int expectedFuelUsed)
        {
            // Arrange
            int actualFuelUsed;

            // Act
            //actualFuelUsed = Enumerable.Range(1, moveDistance).Sum();
            actualFuelUsed = moveDistance * (moveDistance + 1) / 2;

            // Assert
            expectedFuelUsed.Should().Be(actualFuelUsed);
        }
        
    }
}