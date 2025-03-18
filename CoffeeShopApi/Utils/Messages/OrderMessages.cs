namespace CoffeeShopApi.Utils.Messages
{
    public static class OrderMessages
    {
        public static string OrderByIdNotFound()
            => "No existe una oreden con ese identificador";

        public static string OrderNotFound()
            => "No hay ordenes pendientes";
    }
}
