namespace CoffeeShopApi.Utils.Exeptions
{
    public class ConflictException:Exception
    {
        public ConflictException(string message,Exception inner): base(message, inner) { }
    }
}
