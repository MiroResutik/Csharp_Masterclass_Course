using Domain;
using Xunit;
using FluentAssertions;

namespace Test_Calculator
{
    public class UnitTest1
    {
        [Fact]
        public void CalculatorTest()
            => new Calculator().Sum(2,2).Should().Be(4); // Shorter version of below code
        //{
        //    var calculator = new Calculator();
        //    var result = calculator.Sum(2, 2);

        //    result.Should().Be(4);
        //    //if (result != 4)
        //    //    throw new Exception($"The Sum(2,2) was expeted to be 4 but it is {result}.");
        //}


    }
}
