using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppOcMundial2.Models
{
    public class User
    {
        public int ID { get; set; }
        public string GUID { get; set; }
        public int UserTypeID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int FamilyCount { get; set; }

        public static async Task<List<User>> GetUsersList()
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync("http://10.140.4.104:8091/api/Users");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }
    }
}
