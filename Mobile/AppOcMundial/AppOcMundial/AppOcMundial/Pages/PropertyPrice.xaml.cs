using AppOcMundial.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<ItemLista> listaItems;

        public int ID { get; set; }
        public PropertyPrice(int id)
        {
            this.ID = id;
            InitializeComponent();
            dtPickInicio.MinimumDate = DateTime.Now.AddDays(1);
            dtPickFim.MinimumDate = DateTime.Now.AddDays(1);
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



            List<ItemLista> itemLista = policies.Join(price, x => x.ID, y => y.CancellationPolicyID, (x, y) => new ItemLista
            {
                Name = x.Name,
                Price = y.Price,
                Date = y.Date.Date,
                ID = y.ID
            }).ToList();

            listaItems = new ObservableCollection<ItemLista>(itemLista);

            lvRules.ItemsSource = listaItems;
        }

        private void SwipeItem_Invoked(object sender, EventArgs e)//REMOVER
        {
            listaItems.RemoveAt(1);

        }

        private void SwipeItem_Invoked_1(object sender, EventArgs e)//EDITAR
        {
            string id = ((MenuItem)sender).CommandParameter.ToString();
            DisplayAlert("Aviso", id, "Ok");
        }

        private void dtPickFim_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime dateFim = (sender as DatePicker).Date;
            DateTime dateInicio = dtPickInicio.Date;
            if (dateFim < dateInicio)
            {
                dtPickFim.Date = dateInicio;
            }
            if (dtPickFim.Date >= DateTime.Now.Date.AddDays(90))
            {
                dtPickFim.Date = dateInicio;
            }
        }

        private void dtPickInicio_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime dateInicio = (sender as DatePicker).Date;
            DateTime dateFim = dtPickFim.Date;
            if (dateInicio > dateFim)
            {
                dtPickInicio.Date = DateTime.Now.Date.AddDays(1);
            }
        }
    }
}