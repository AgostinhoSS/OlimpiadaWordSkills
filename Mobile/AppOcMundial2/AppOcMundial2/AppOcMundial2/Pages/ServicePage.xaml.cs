using AppOcMundial2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOcMundial2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicePage : ContentPage
    {
        ObservableCollection<ServiceType> Services { get; set; }
        public ServicePage()
        {
            User usuarioLogado = MainPage.UsuarioLogado;
            InitializeComponent();
            txtUsername.BindingContext = usuarioLogado;
            HttpClient client = new HttpClient();
            string json = client.GetStringAsync("http://172.20.192.1:8092/api/ServiceTypes").Result;
            List<ServiceType> listaServices = JsonConvert.DeserializeObject<List<ServiceType>>(json);
            Services = new ObservableCollection<ServiceType>(listaServices);
            ListaServices.ItemsSource = Services;
        }



        private void ListaServices_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                ServiceType item = e.SelectedItem as ServiceType;
                App.Current.MainPage = new SelectedServicePage(item);
                
               
            }
        }
    }
}