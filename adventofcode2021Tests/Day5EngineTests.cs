using FluentAssertions;
using Xunit;
using adventofcode2021.Puzzles.Day5;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode2021Tests
{
    public class Day5EngineTests
    {
        [Theory]
        [InlineData(2, "96,897 -> 984,897", "88,897 -> 984,332", "96,333 -> 96,897")]
        [InlineData(2, "0,0 -> 900,0", "88,897 -> 984,332", "100,101 -> 100,101")]
        public void Finds_Straight_Line_Coords(int expectedValue, params string[] input)
        {
            // Arrange
            IEnumerable<string> result;

            // Act
            result = input.Where(l => Day5Engine.IsStraightLine(l));

            // Assert
            result.ToList().Count().Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("0,0 -> 0,5", "0,0", "0,1", "0,2", "0,3", "0,4", "0,5")]
        [InlineData("0,0 -> 0,0", "0,0")]
        [InlineData("0,5 -> 0,0", "0,0", "0,1", "0,2", "0,3", "0,4", "0,5")]
        [InlineData("1,1 -> 3,3", "1,1", "2,2", "3,3")]
        [InlineData("9,7 -> 7,9", "9,7", "8,8", "7,9")]
        [InlineData("1,1 -> 4,4", "1,1", "2,2", "3,3", "4,4")]
        [InlineData("4,4 -> 1,1", "1,1", "2,2", "3,3", "4,4")]
        [InlineData("1,4 -> 4,1", "1,4", "2,3", "3,2", "4,1")]
        [InlineData("4,1 -> 1,4", "1,4", "2,3", "3,2", "4,1")]

        public void Should_Generate_Points_For_Line_Coords(string input, params string[] expectedValue)
        {
            // Arrange
            var sut = new Day5Engine();
            IEnumerable<string> result;

            // Act
            result = sut.GeneratePointsForLineCoords(input);

            // Assert
            result.Should().Contain(expectedValue).And.HaveCount(expectedValue.Count());
        }

        [Theory]
        [InlineData(6, "0,0 -> 0,5")]
        [InlineData(6, "0,0 -> 5,0")]
        [InlineData(10, "1,1 -> 10,1")]
        [InlineData(1, "1,1 -> 1,1")]
        [InlineData(11, "0,0 -> 0,0", "1,1 -> 10,1")]
        public void Should_Record_Unique_LinePoints_When_Lines_Plotted(int expectedValue, params string[] input)
        {
            // Arrange
            var sut = new Day5Engine();
            IDictionary<string, int> result;

            // Act
            result = sut.PlotLines(input);

            // Assert
            result.Count().Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(1, "1,1 -> 1,1", "1,1 -> 1, 2")]
        [InlineData(3, "5,0 -> 5,5", "1,1 -> 5, 1", "1,3 -> 5, 3", "1,5 -> 5, 5")]
        public void Should_Record_Overlap_LinePoints_When_Lines_Plotted(int expectedValue, params string[] input)
        {
            // Arrange
            var sut = new Day5Engine();
            IDictionary<string, int> result;

            // Act
            result = sut.PlotLines(input);

            // Assert
            result.Values.Where(v=>v > 1).Count().Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(5, "0,9 -> 5,9", "8,0 -> 0,8", "9,4 -> 3,4", "2,2 -> 2,1", "7,0 -> 7,4", "6,4 -> 2,0", "0,9 -> 2,9", "3,4 -> 1,4", "0,0 -> 8,8", "5,5 -> 8,2")]
        public void Should_Record_Overlap_LinePoints_For_Straight_Lines_Plotted(int expectedValue, params string[] input)
        {
            // Arrange
            var sut = new Day5Engine();
            int result;

            // Act
            sut.Part1(input, out result);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(12, "0,9 -> 5,9", "8,0 -> 0,8", "9,4 -> 3,4", "2,2 -> 2,1", "7,0 -> 7,4", "6,4 -> 2,0", "0,9 -> 2,9", "3,4 -> 1,4", "0,0 -> 8,8", "5,5 -> 8,2")]
        public void Should_Record_Overlap_LinePoints_For_All_Lines_Plotted(int expectedValue, params string[] input)
        {
            // Arrange
            var sut = new Day5Engine();
            int result;

            // Act
            sut.Part2(input, out result);

            // Assert
            result.Should().Be(expectedValue);
        }
    }
}
