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
	public partial class AddProducts : ContentPage
	{
		public AddProducts ()
		{
			InitializeComponent ();
		}

        private void saveProduct_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", "Save a Product", "ok");
        }

        private void takePictureProduct_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", "Take a picture", "ok");
        }
    }
}