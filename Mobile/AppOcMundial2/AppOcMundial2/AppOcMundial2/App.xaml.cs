using AppOcMundial2.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOcMundial2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
