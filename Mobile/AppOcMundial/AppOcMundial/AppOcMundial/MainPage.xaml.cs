using AppOcMundial.Models;
using AppOcMundial.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppOcMundial
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync("http://10.140.4.104:8090/api/Users");
                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                string nome = txtNome.Text;
                string senha = txtSenha.Text;
                int quantUsu = users.Where(x => x.Username == nome && x.Password == senha).Count();

                if (quantUsu == 0)
                {
                    await DisplayAlert("Aviso", "Login Incorreto!", "OK");
                }
                else
                {
                    await Navigation.PushAsync(new PropertyPage());
                }
            }
        }
    }
}

