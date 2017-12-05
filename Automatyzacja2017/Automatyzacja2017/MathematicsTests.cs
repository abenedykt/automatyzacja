using System;
using Xunit;

namespace UnitTests
{
    public class MathematicsTests
    {
        [Theory]
        [InlineData(10.0, 20.0, 30.0)]
        [InlineData(1, 2, 3)]
        [InlineData(-10, 20, 10)]
        [InlineData(-10, 10, 0)]
        [
            InlineData(1000000, 1000000, 2000000),
            InlineData(0,0,0),
            InlineData(-0d, 0d, -0d)
        ]
        public void Add_method_should_return_sum_of_given_arguments(double x, double y, double expected)
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Add(x, y);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Method_substract_returns_difference_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Substract(10, 20);

            // assert
            Assert.Equal(-10, result);
        }

        [Fact]
        public void Method_multiply_returns_multiplication_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Multiply(10, 20);

            // assert
            Assert.Equal(200, result);
        }

        [Fact]
        public void Method_divide_returns_division_of_given_values()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Divide(25, 5);

            // assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void When_divising_by_zero_divide_throws_cannot_divide_by_zero_exception()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Divide(25, 0);

            Assert.True(double.IsInfinity(result));
        }

        [Fact]
        public void When_divising_by_zero2_divide_throws_cannot_divide_by_zero_exception()
        {
            // arrange
            var math = new Mathematics();

            Assert.Throws<DivideByZeroException>(() => math.Divide2(25, 0));
        }
    }
}
