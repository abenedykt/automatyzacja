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

        [Fact]
        public void Method_substract_returns_sum_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Substract(10, 20);

            // assert
            Assert.Equal(-10, result);
        }

        [Fact]
        public void Method_multiply_returns_sum_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Multiply(10, 20);

            // assert
            Assert.Equal(200, result);
        }

        [Fact]
        public void Method_divide_returns_sum_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Divide(25, 5);

            // assert
            Assert.Equal(5, result);
        }
    }
}
