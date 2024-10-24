using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample
{
  public class CalculatorService
  {
    private readonly ICalculator calculator;

    public CalculatorService(ICalculator calculator)
    {
      this.calculator = calculator;
    }


    public int Sum(int number1, int number2)
    {
      return this.calculator.Sum(number1, number2);
    }
  }
}
