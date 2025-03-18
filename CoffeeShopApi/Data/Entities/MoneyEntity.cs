namespace CoffeeShopApi.Data.Entities
{
    public class MoneyEntity
    {
        private int _cents;

        public MoneyEntity() { }

        public MoneyEntity(int cents)
        {
            _cents = cents;
        }

        public MoneyEntity(decimal cash)
        {
            _cents = (int)(cash * 100);
        }

        public decimal Cash => (decimal)_cents / 100;

        public int Cents => _cents;

        public static MoneyEntity operator +(MoneyEntity a, MoneyEntity b)
        {
            return new MoneyEntity(a._cents + b._cents);
        }

        public static MoneyEntity operator -(MoneyEntity a, MoneyEntity b)
        {
            return new MoneyEntity(a._cents - b._cents);
        }

        public override string ToString()
        {
            return Cash.ToString("$"); // Formato de moneda
        }

    }
}
