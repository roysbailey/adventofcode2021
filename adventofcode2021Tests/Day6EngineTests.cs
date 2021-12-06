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
        [InlineData(1, 5, "3,4,3,1,2")]
        [InlineData(2, 6, "3,4,3,1,2")]
        [InlineData(18, 26, "3,4,3,1,2")]
        [InlineData(80, 5934, "3,4,3,1,2")]
        [InlineData(256, 26984457539, "3,4,3,1,2")]
        public void Simulating_LatnerFish_Produces_Correct_Fish_Count_For_Simulated_Days(int daysToSimulate, long expectedValue, string lanternFish)
        {
            // Arrange
            var sut = new Day6Engine();

            // Act
            var result = sut.SimulateLanternFishReproduction(lanternFish, daysToSimulate);

            // Assert
            result.Should().Be(expectedValue);
        }

        //[Theory]
        //[InlineData("3,4,3,1,2", 1, 2, 3, 2, 0, 1)]
        //[InlineData("2,3,2,0,1", 1, 1, 2, 1, 6, 0, 8)]
        //[InlineData("3,4,3,1,2", 2, 1, 2, 1, 6, 0, 8)]
        //[InlineData("3,4,3,1,2", 18, 6, 0, 6, 4, 5, 6, 0, 1, 1, 2, 6, 0, 1, 1, 1, 2, 2, 3, 3, 4, 6, 7, 8, 8, 8, 8)]

        //public void Simulating_LatnerFish_Produces_Correct_Fish_Output_For_Simulated_Days(string lanternFish, int daysToSimulate, params int[] expectedValues)
        //{
        //    // Arrange
        //    var sut = new Day6Engine();

        //    // Act
        //    var result = sut.SimulateLanternFish(lanternFish, daysToSimulate);

        //    // Assert
        //    result.Should().Contain(expectedValues).And.HaveCount(expectedValues.Count());
        //}
    }
}