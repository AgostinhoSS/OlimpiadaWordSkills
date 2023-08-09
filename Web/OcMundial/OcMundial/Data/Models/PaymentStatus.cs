namespace OcMundial.Data.Models
{
    public class PaymentStatus
    {
        public string cardNo { get; set; }
        public string orderId { get; set; }
        public string extraInfo { get; set; }
        public string status { get; set; }
        public string trackId { get; set; }
        public double price { get; set; }
        public string callBackUrl { get; set; }
        public bool verify { get; set; }


    }
}
