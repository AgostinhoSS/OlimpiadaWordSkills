using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppOcMundial.Models
{
    public class Item
    {

        public int id { get; set; }
        public Guid GUID { get; set; }
        public int UserID { get; set; }
        public int ItemTypeID { get; set; }
        public int AreaID { get; set; }
        public string Title { get; set; }
        public int Capacity { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public string ExactAddress{ get; set; }
        public string ApproximateAddres { get; set; }
        public string Description { get; set; }
        public string HostRules { get; set; }
        public int MinimumNights { get; set; }
        public int MaximumNights { get; set; }

        

    }
}
