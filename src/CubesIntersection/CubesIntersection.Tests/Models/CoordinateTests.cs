using AutoFixture;
using CubesIntersection.Domain.Models;
using FluentAssertions;
using Xunit;

namespace CubesIntersection.Tests.Models
{
    public class CoordinateTests
    {
        [Fact]
        public void Constructor_ShouldSetXYZ()
        {
            // Prepare
            var fixture = new Fixture();
            float fakeX = fixture.Create<float>();
            float fakeY = fixture.Create<float>();
            float fakeZ = fixture.Create<float>();

            // Act
            var sut = new Coordinate(fakeX, fakeY, fakeZ);

            // Assert
            sut.X.Should().Be(fakeX);
            sut.Y.Should().Be(fakeY);
            sut.Z.Should().Be(fakeZ);
        }

        [Fact]
        public void Clone_ShouldReturnANewInstanceWithACopyOfXYZ()
        {
            // Prepare
            var fixture = new Fixture();
            float fakeX = fixture.Create<float>();
            float fakeY = fixture.Create<float>();
            float fakeZ = fixture.Create<float>();
            var origin = new Coordinate(fakeX, fakeY, fakeZ);

            // Act
            var sut = origin.Clone();

            // Assert
            sut.Should().NotBeSameAs(origin);
            sut.X.Should().Be(fakeX);
            sut.Y.Should().Be(fakeY);
            sut.Z.Should().Be(fakeZ);
        }
    }
}
