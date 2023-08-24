using AppOcMundial2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppOcMundial2.Pages;

namespace AppOcMundial2
{
    public partial class MainPage : ContentPage
    {
        public static User UsuarioLogado;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string senha = txtPasword.Text;
            string username = txtUsername.Text;
            List<User> users = await User.GetUsersList();
            User usuLogado = users.Where(x => x.Username == username && x.Password == senha).FirstOrDefault();
            if (usuLogado == null)
            {
                DisplayAlert("Aviso", "Login Incorreto!", "Ok");
            }
            else
            {
                DisplayAlert("Aviso", "Login Realizado com Sucesso!", "Ok");
                UsuarioLogado= usuLogado;
                App.Current.MainPage = new ServicePage();
                
            }
        }
    }
}
