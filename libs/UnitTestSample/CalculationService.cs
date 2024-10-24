using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample
{
  public class CalculationService
  {

    public int Sum(int number1, int number2)
    {
      Thread.Sleep(5000); // uzun süren bir işlem varsa otomatik olarak unitest burdaki kod bağlı olduğundan test süresi uzuyor.

      return number1 + number2;
    }

    public int Division(int number1, int number2)
    {
      Thread.Sleep(5000);

      return number1 / number2;
    }
  }
}
