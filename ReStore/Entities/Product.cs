namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }  // Using Long instead of decimal because this is what "Stripe and Sqlite use Long instead of decimal"

        public string PictureUrl { get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }

        public int QuantityInStock { get; set; }
    }
}
