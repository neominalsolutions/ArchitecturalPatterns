namespace AspectOrientedPrograming.Services
{
  // Payment sürecini yönteceğimiz ortak arayüz
  public interface IPayment
  {
    void Pay(decimal amount, string currency);

  }
}
