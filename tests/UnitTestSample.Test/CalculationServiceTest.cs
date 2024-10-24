using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Test
{
  public class CalculationServiceTest
  {

    // [Fact] attribute test methodu dışarıdan değer almıyorsa tercih edilir. 
    // [Theory] dışarıdan test methoduna parametre gönderiyorsak kullanırız

    [Fact]
    public void Sum_TwoIntegerVariable_ReturnTotalValue()
    {
      // Arrange => servisin hazırlık aşaması
      var service = new CalculationService();

      // Act => servise ait methodu tetikleme aşaması
      int actualValue = service.Sum(10, 20); // güncel değer

      // Assert => beklenen değer ile servisten dönen değerin kontrolü

      // her yazılan Assert ifadelerin doğru sonuç döndürmesi lazım ki testen geçelim.
      Assert.Equal<int>(30, actualValue); // testen geçeceğiz
      Assert.True(30 == actualValue); // 2. test case

    }


    [Theory]
    [InlineData(2,2,1)]
    [InlineData(7, 2, 3)]
    public void Divide_TwoIntegerVariable_ReturnValue(int number1, int number2, int result)
    {
      // Arrange => servisin hazırlık aşaması
      var service = new CalculationService();

      // Act => servise ait methodu tetikleme aşaması
      int actualValue = service.Division(number1,number2); // güncel değer

      // Assert => beklenen değer ile servisten dönen değerin kontrolü
      Assert.Equal<int>(result, actualValue);

    }




  }
}
