using AppOcES.Models;
using AppOcES.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppOcES
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SolicitarAcessoPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DefinirSenhaPage());
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtMatricula.Text.Length == 11)
            {
                string matricula = txtMatricula.Text;
                if (GetAlunoByCpfAsync(matricula).Result != null)
                {
                    DisplayAlert("AVISO", "ALUNO ENCONTRADO!", "OK");
                }

            }

        }

        private async Task<Aluno> GetAlunoByCpfAsync(string cpf)
        {
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync("http://10.140.4.104:8092/api/tblAlunoes");
            List<Aluno> alunos = JsonConvert.DeserializeObject<List<Aluno>>(json);
            Aluno aluno = alunos.Where(z => z.CPF == cpf).FirstOrDefault();
            return aluno;
        }
    }
}
