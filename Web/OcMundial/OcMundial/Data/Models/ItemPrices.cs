namespace OcMundial.Data.Models
{
    public class ItemPrices
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public string Description { get; set; }
        public string HostRules { get; set; }
        public decimal Price { get; set; }
    }
}
