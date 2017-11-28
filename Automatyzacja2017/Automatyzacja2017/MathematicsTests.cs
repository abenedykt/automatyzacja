using Xunit;

namespace Automatyzacja2017
{
    public class MathematicsTests
    {
        [Fact]
        public void Method_add_returns_sum_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Add(10, 20);

            // assert
            Assert.Equal(30, result);
        }
    }
}
