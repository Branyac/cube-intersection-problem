using CubesIntersection.Domain.Implementations;
using CubesIntersection.Domain.Models;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CubesIntersection.Tests.Implementations
{
    public class CubeIntersectorTests
    {
        [Theory]
        [MemberData(nameof(GetTestDataWhenThereIsAnIntersection))]
        public void GetIntersection_WhenThereIsAnIntersection_ReturnsIntersection(Rectangle shapeOne, Rectangle shapeTwo, Rectangle expectedResultShape, float expectedResultVolume)
        {
            // Prepare
            var sut = new IntersectionService();

            // Act
            var result = sut.GetIntersection(shapeOne, shapeTwo);

            // Assert
            result.Should().NotBeNull();

            result.Start.X.Should().BeApproximately(expectedResultShape.Start.X, IntersectionService.PRECISION * 2);
            result.Start.Y.Should().BeApproximately(expectedResultShape.Start.Y, IntersectionService.PRECISION * 2);
            result.Start.Z.Should().BeApproximately(expectedResultShape.Start.Z, IntersectionService.PRECISION * 2);

            result.End.X.Should().BeApproximately(expectedResultShape.End.X, IntersectionService.PRECISION * 2);
            result.End.Y.Should().BeApproximately(expectedResultShape.End.Y, IntersectionService.PRECISION * 2);
            result.End.Z.Should().BeApproximately(expectedResultShape.End.Z, IntersectionService.PRECISION * 2);

            result.GetVolume().Should().BeApproximately(expectedResultVolume, IntersectionService.PRECISION * 8);
        }

        public static IEnumerable<object[]> GetTestDataWhenThereIsAnIntersection =>
            new List<object[]>
            {
                new object[] {
                    new Rectangle(
                        new Coordinate(-5, -5, -5),
                        new Coordinate(5, 5, 5)
                        ),
                    new Rectangle(
                        new Coordinate(-5, -5, -5),
                        new Coordinate(5, 5, 5)
                        ),
                    new Rectangle(
                        new Coordinate(-5, -5, -5),
                        new Coordinate(5, 5, 5)
                        ),
                    1000
                },
                new object[] {
                    new Rectangle(
                        new Coordinate(-5, -5, -5),
                        new Coordinate(5, 5, 5)
                        ),
                    new Rectangle(
                        new Coordinate(0, 0, 0),
                        new Coordinate(5, 5, 5)
                        ),
                    new Rectangle(
                        new Coordinate(0, 0, 0),
                        new Coordinate(5, 5, 5)
                        ),
                    117
                },
                new object[] {
                    new Rectangle(
                        new Coordinate(-5, -5, -5),
                        new Coordinate(5, 5, 5)
                        ),
                    new Rectangle(
                        new Coordinate(-5, -5, -5),
                        new Coordinate(0, 0, 0)
                        ),
                    new Rectangle(
                        new Coordinate(-5, -5, -5),
                        new Coordinate(0, 0, 0)
                        ),
                    125
                }
            };

        [Theory]
        [MemberData(nameof(GetTestDataWhenNoIntersection))]
        public void GetIntersection_WhenNoIntersection_ReturnsNull(Rectangle shapeOne, Rectangle shapeTwo)
        {
            // Prepare
            var sut = new IntersectionService();

            // Act
            var result = sut.GetIntersection(shapeOne, shapeTwo);

            // Assert
            result.Should().BeNull();
        }

        public static IEnumerable<object[]> GetTestDataWhenNoIntersection =>
            new List<object[]>
            {
                new object[] {
                    new Rectangle(
                        new Coordinate(-5, -5, -5),
                        new Coordinate(5, 5, 5)
                        ),
                    new Rectangle(
                        new Coordinate(10, 10, 10),
                        new Coordinate(25, 25, 25)
                        ),
                },
                new object[] {
                    new Rectangle(
                        new Coordinate(-10, -10, -10),
                        new Coordinate(-5, -5, -5)
                        ),
                    new Rectangle(
                        new Coordinate(-3, -3, -3),
                        new Coordinate(25, 25, 25)
                        ),
                },
                new object[] {
                    new Rectangle(
                        new Coordinate(10, 10, 10),
                        new Coordinate(15, 15, 15)
                        ),
                    new Rectangle(
                        new Coordinate(30, 30, 30),
                        new Coordinate(35, 35, 35)
                        )
                }
            };
    }
}
            
