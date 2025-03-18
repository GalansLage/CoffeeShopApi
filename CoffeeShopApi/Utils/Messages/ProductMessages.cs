namespace CoffeeShopApi.Utils.Messages
{
    public static class ProductMessages
    {
        public static string ProductByIdNotFound()
            => "No existe un producto con ese identificador";

        public static string ProductNotFound()
            => "No hay productos en el inventario";
    }
}
