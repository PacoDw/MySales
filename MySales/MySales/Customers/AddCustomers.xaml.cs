using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySales
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCustomers : ContentPage
	{
		public AddCustomers ()
		{
			InitializeComponent ();
		}

        private void saveCustomer_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", "Save a Customer", "ok");
        }

        private void takePictureCustomer_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", "Take a picture", "ok");
        }
    }
}