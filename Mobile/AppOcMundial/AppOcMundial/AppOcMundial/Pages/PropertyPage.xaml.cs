using AppOcMundial.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOcMundial.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyPage : ContentPage
    {
        public PropertyPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            HttpClient client = new HttpClient();
            string json = client.GetStringAsync("http://10.140.4.104:8090/api/Items").Result;
            List<Item> listaItens = JsonConvert.DeserializeObject<List<Item>>(json);


            //lvProperties.ItemsSource = listaItens.Join(listaPrecos, x => x.id, y => y.ItemId, (x, y) => new { Title = x.Title, Id = x.id, Date = y.Date });

            foreach (Item item in listaItens)
            {
                StackLayout stack = new StackLayout() { BackgroundColor = Color.LightGray, Orientation = StackOrientation.Horizontal, Padding = 10, HorizontalOptions = LayoutOptions.Fill };
                Frame frame = new Frame
                {
                    CornerRadius = 100,
                    Padding = 0,
                    IsClippedToBounds = true,
                    WidthRequest = 50,
                    HeightRequest = 50,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    Content = new Image
                    {
                        Source = ImageSource.FromFile("download.png"),
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Aspect = Aspect.Fill,
                    }
                };

                json = client.GetStringAsync("http://10.140.4.104:8090/api/ItemPrices").Result;
                List<ItemPrices> listaPrecos = JsonConvert.DeserializeObject<List<ItemPrices>>(json);
                ItemPrices price = listaPrecos.Where(x => x.ItemId == item.id && x.Date == listaPrecos.Max(y => y.Date)).FirstOrDefault<ItemPrices>();

                StackLayout stackLayout = new StackLayout() { Orientation = StackOrientation.Vertical, Margin = 10 };
                Label label1 = new Label() { Text = item.Title, VerticalOptions = LayoutOptions.Start, FontSize = 15 };
                Label label2;
                if (price == null)
                {
                    label2 = new Label() { Text = "Last date of pricing: --/--/----", VerticalOptions = LayoutOptions.End };
                }
                else
                {
                    if (price.Date.AddDays(5) < DateTime.Now)
                    {
                        label2 = new Label() { Text = "Last date of pricing:" + price.Date.ToString("dd/MM/yyyy"), VerticalOptions = LayoutOptions.End, TextColor = Color.Red };
                    }
                    else
                    {
                        label2 = new Label() { Text = "Last date of pricing:" + price.Date.ToString("dd/MM/yyyy"), VerticalOptions = LayoutOptions.End };
                    }

                }

                Label lblId = new Label() { Text = item.id.ToString(), IsVisible = false };
                string id = item.id.ToString();
                Image image1 = new Image() { AutomationId = id, Margin = 0, Source = ImageSource.FromFile("coin.png"), HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.Center, WidthRequest = 35, HeightRequest = 35, Aspect = Aspect.Fill };
                TapGestureRecognizer tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += TapGestureRecognizer_Tapped;

                image1.GestureRecognizers.Add(tapGesture);

                stackLayout.Children.Add(label1);
                stackLayout.Children.Add(label2);

                stack.Children.Add(frame);
                stack.Children.Add(stackLayout);
                stack.Children.Add(image1);
                stack.Children.Add(lblId);
                ListaPropriedades.Children.Add(stack);


            }
        }



        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as Image).AutomationId);

            Navigation.PushAsync(new PropertyPrice(id));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool teste = await DisplayAlert("Aviso", "Deseja encerrar o aplicativo?", "Sim", "Não");
            if (teste)
            {
                App.Current.Quit();
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton imgButton = (sender as ImageButton);
            if (imgButton != null)
            {
                string teste = imgButton.AutomationId;
                DisplayAlert("teste", teste, "ok");
            }

        }
    }
}