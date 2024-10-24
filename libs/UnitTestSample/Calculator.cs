using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample
{
  public class Calculator : ICalculator
  {
    public int Sum(int number1, int number2)
    {
      Thread.Sleep(5000);

      return number1 + number2;
    }
  }
}
