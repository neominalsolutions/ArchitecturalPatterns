namespace AspectOrientedPrograming.Services
{
  public class VirtualWalletPayment : IPayment
  {
    public void Pay(decimal amount, string currency)
    {
      Console.WriteLine("Sanal Cüzdan ile ödeme yap");
    }
  }
}
