using AppOcMundial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppOcMundial2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedServicePage : ContentPage
	{
		public SelectedServicePage (ServiceType service)
		{
			InitializeComponent ();
		}
	}
}