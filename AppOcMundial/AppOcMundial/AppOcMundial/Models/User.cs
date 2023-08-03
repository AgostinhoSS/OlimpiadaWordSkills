using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppOcMundial.Models
{
    public class User
    {
        public int ID { get; set; }
        public string GUID { get; set; }
        public int UserTypeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int FamilyCount { get; set; }

        /*
        public static async Task<List<User>> GetUsers()
        {
           
        }
        */
    }
}
