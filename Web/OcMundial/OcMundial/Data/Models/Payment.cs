using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace OcMundial.Data.Models
{
    public class Payment
    {
        public string customer { get; set; }
        public string orderId { get; set; }
        public double price { get; set; }
        public string extraInfo { get; set; }
        public string callBackUrl { get; set; }
    }
}
