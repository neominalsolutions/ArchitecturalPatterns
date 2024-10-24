namespace AspectOrientedPrograming.Services
{
  public class CreditCardPayment : IPayment
  {
    //[BenchMark]
    //[LogInfo]
    public void Pay(decimal amount, string currency)
    {
      Console.WriteLine("Kredi Kartı ile Ödeme algoritması");
    }
  }
}
