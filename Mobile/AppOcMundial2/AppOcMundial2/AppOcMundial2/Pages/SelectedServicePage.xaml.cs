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
            string json = client.GetStringAsync("http://10.140.4.104:8091/api/Services").Result;
            List<Services> services = JsonConvert.DeserializeObject<List<Services>>(json);
            services = services.Where(x => x.ServiceTypeID == service.ID).ToList();
            Services selectedUser = services.Where(x => x.ServiceTypeID == service.ID).FirstOrDefault<Services>();

            txtDescricao.BindingContext = service;
            if (services.Count != 0)
            {
                ListaServices = new ObservableCollection<Services>(services);
                lvServices.ItemsSource = ListaServices;
            }
            else
            {
                ListaServices = new ObservableCollection<Services>() 
                {
                    new Services()
                    { 
                        Name = "Não há serviços Cadastrados!",
                        
                    }
                };
                lvServices.ItemsSource = ListaServices;
            }
            

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

        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ServicePage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new ServicePage();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            App.Current.MainPage = new CartPage();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            App.Current.MainPage = new AboutPage();
        }
    }
}