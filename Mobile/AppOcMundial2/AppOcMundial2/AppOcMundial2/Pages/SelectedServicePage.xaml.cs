using AppOcMundial2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOcMundial2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedServicePage : ContentPage
    {
        ObservableCollection<Services> ListaServices;

        public SelectedServicePage(ServiceType service)
        {
            InitializeComponent();
            txtTitle.BindingContext = service;
            HttpClient client = new HttpClient();
            string json = client.GetStringAsync("http://172.24.80.1:8095/api/Services").Result;
            List<Services> services = JsonConvert.DeserializeObject<List<Services>>(json);
            Services selectedUser = services.Where(x => x.ServiceTypeID == service.ID).FirstOrDefault<Services>();
            txtDescricao.BindingContext = service;
            ListaServices = new ObservableCollection<Services>(services);
            lvServices.ItemsSource = ListaServices;
        }

        private void lvServices_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Services tappedService = e.SelectedItem as Services;

            if (tappedService != null)
            {
                lvServices.HeightRequest = 225;
                txtServiceName.BindingContext = tappedService;
                txtServiceDesc.BindingContext = tappedService;
                slSetPrice.IsVisible = true;

            }

            
        }
    }
}