namespace CoffeeShopApi.Utils.Exeptions
{
    public class ReferenceException: Exception
    {
        public ReferenceException()
        {
        }

        public ReferenceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
