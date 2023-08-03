using System;
using System.Collections.Generic;
using System.Text;

namespace AppOcMundial.Models
{
    internal class ItemPrices
    {
        public int ID { get; set; }
        public Guid GUID { get; set; }
        public long ItemId { get; set; }
        public DateTime Date{ get; set; }
        public double Price{ get; set; }
        public long CancellationPolicyID { get; set; }

    }
}
