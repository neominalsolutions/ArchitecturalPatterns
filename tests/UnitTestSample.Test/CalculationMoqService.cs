using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Test
{
  public class CalculationMoqService
  {

    private readonly CalculatorService calculatorService;
    private readonly Mock<ICalculator> mock; // simüle ettiğimiz sınıf.
                                             // Calculator sınıfı içindeki toplama işlemini simüle ediyoruz.

    public CalculationMoqService()
    {
      mock = new Mock<ICalculator>();
      // mock.Object simüle edilen sınıfın instance
      calculatorService = new CalculatorService(mock.Object);

    }

    [Fact]
    public void Sum_TwoIntegerVariable_ReturnTotalValue()
    {
      // Arrange => mock üzerinden gönderilen parametreler ile servisi simüle ettim.
      mock.Setup(x => x.Sum(10, 20)).Returns(30);

      // Act => servise ait methodu tetikleme aşaması
      int actualValue = calculatorService.Sum(10, 20);


      // Assert => beklenen değer ile servisten dönen değerin kontrolü

      // her yazılan Assert ifadelerin doğru sonuç döndürmesi lazım ki testen geçelim.
      Assert.Equal<int>(30, actualValue); // testen geçeceğiz

      mock.Verify(x => x.Sum(10, 20), Times.AtLeast(1));

    }


    [Theory]
    [InlineData(1,1,2)]
    [InlineData(2, 3, 5)]
    public void Sum2_TwoIntegerVariable_ReturnTotalValue(int number1,int number2, int sum)
    {
      // Arrange => mock üzerinden gönderilen parametreler ile servisi simüle ettim.
      mock.Setup(x => x.Sum(number1, number2)).Returns(sum);

      // Act => servise ait methodu tetikleme aşaması
      int actualValue = calculatorService.Sum(number1, number2);


      // Assert => beklenen değer ile servisten dönen değerin kontrolü

      // her yazılan Assert ifadelerin doğru sonuç döndürmesi lazım ki testen geçelim.
      Assert.Equal<int>(sum, actualValue); // testen geçeceğiz

      mock.Verify(x => x.Sum(number1, number2), Times.AtLeast(1));

    }
  }
}
