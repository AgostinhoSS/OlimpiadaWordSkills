using AppOcMundial.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOcMundial.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyPrice : ContentPage
    {
        public int ID { get; set; }
        public PropertyPrice(int id)
        {
            this.ID = id;
            InitializeComponent();
            HttpClient client = new HttpClient();

            string json = client.GetStringAsync("http://10.140.4.104:8090/api/Items/" + ID).Result;
            Item item = JsonConvert.DeserializeObject<Item>(json);
            lblTitulo.Text = item.Title;
            string[] regras = item.HostRules.Split(',');
            List<string> rules = new List<string>(regras);
            rule1.ItemsSource = rules;
            rule2.ItemsSource = rules;
            rule3.ItemsSource = rules;

            json = client.GetStringAsync("http://10.140.4.104:8090/api/ItemPrices").Result;
            List<ItemPrices> price = JsonConvert.DeserializeObject<List<ItemPrices>>(json);
            price = price.Where(x => x.ItemId == item.id).ToList();

            json = client.GetStringAsync("http://10.140.4.104:8090/api/CancellationPolicies").Result;
            List<CancellationPolicie> policies = JsonConvert.DeserializeObject<List<CancellationPolicie>>(json);


            var lista = policies.Join(price, x => x.ID, y => y.CancellationPolicyID, (x, y) => new { x.Name, y.Price, y.Date.Date,y.ID }).ToList();
            lvRules.ItemsSource = lista;
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
            string id = ((MenuItem)sender).CommandParameter.ToString();
            DisplayAlert("Aviso", id, "Ok");
        }

        private void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            string id = ((MenuItem)sender).CommandParameter.ToString();
            DisplayAlert("Aviso", id, "Ok");
        }
    }
}