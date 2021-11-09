using CubesIntersection.Domain.Models;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CubesIntersection.Tests.Models
{
    public class RectangleTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void GetVolume_ShouldBeCorrect(Rectangle sut, float expectedVolume)
        {
            // Act
            var volume = sut.GetVolume();

            // Assert
            volume.Should().Be(expectedVolume);
        }

        public static IEnumerable<object[]> GetTestData =>
            new List<object[]>
            {
                new object[] {
                    new Rectangle(
                        new Coordinate(0, 0, 0),
                        new Coordinate(3, 3, 3)
                    ),
                    27f
                },
                new object[] {
                    new Rectangle(
                        new Coordinate(0, 0, 0),
                        new Coordinate(5, 5, 5)
                    ),
                    125f
                }
            };
    }
}
