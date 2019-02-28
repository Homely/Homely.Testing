using Shouldly;
using System;
using Xunit;

namespace Homely.Common.Testing.Tests
{
    public class ShouldLookLikeTests
    {
        [Theory]
        [MemberData(nameof(FakeData.EqualData), MemberType =typeof(FakeData))]
        public void GivenTwoEqualModels_ShouldLookLike_ShouldNotThrowAnException(FakeFoo actual, FakeFoo expected)
        {
            // Arrange, Act & Assert.
            actual.ShouldLookLike(expected);
        }

        [Fact]
        public void GivenTwoUnequalModels_ShouldLookLike_ShouldThrowAnException()
        {
            // Arrange.
            var actual = new FakeFoo();
            var expected = new FakeFoo
            {
                Id = 1
            };

            // Act.
            var exception = Should.Throw<Exception>(() => actual.ShouldLookLike(expected));

            // Assert.
            exception.ShouldNotBeNull();
        }
    }
}
