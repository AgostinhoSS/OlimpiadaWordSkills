using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppOcMundial2.Models
{
    public class ServiceType
    {
        public int ID { get; set; }
        public string GUID { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public string Description { get; set; }

      
    }
}
