namespace BlazorApp1.Data.Models
{
    public class Items
    {
        public int Id { get; set; }
        public Guid MyProperty { get; set; }
        public int UserID { get; set; }

        public int ItemTypeID { get; set; }
        public int AreaID { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public string ExactAddress { get; set; }
        public string ApproximateAddress { get; set; }
        public string Description { get; set; }
        public string HostRules { get; set; }
        public int MinimumNights { get; set; }
        public int MaximumNights { get; set; }
    }
}
