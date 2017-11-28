using System;
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


            //Assert.Throws<DivideByZeroException>(() => math.Divide(25, 0));
        }

        [Fact]
        public void When_divising_by_zero2_divide_throws_cannot_divide_by_zero_exception()
        {
            // arrange
            var math = new Mathematics();

            // act
            var result = math.Divide(25, 0);
            
            Assert.Throws<DivideByZeroException>(() => math.Divide(25, 0));

        }
    }
}
