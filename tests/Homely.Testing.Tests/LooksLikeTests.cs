using Shouldly;
using Xunit;

namespace Homely.Testing.Tests
{
    public class LooksLikeTests
    {
        [Theory]
        [MemberData(nameof(FakeData.EqualData), MemberType =typeof(FakeData))]
        public void GivenTwoEqualModels_LooksLike_ShouldReturnTrue(FakeFoo actual, FakeFoo expected)
        {
            // Arrange & Act.
            var result = actual.LooksLike(expected);

            // Assert.
            result.ShouldBeTrue();
        }

        [Fact]
        public void GivenTwoUnequalModels_LooksLike_ShouldReturnFalse()
        {
            // Arrange.
            var actual = new FakeFoo();
            var expected = new FakeFoo
            {
                Id = 1
            };

            // Act.
            var result = actual.LooksLike(expected);

            // Assert.
            result.ShouldBeFalse();
        }
    }
}
