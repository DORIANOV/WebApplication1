namespace BeerSupplyAPI.Models
{
    public class Keg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ReorderThreshold { get; set; }
    }
}
