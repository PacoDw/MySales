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
	public partial class Products : ContentPage
	{
		public Products ()
		{
			InitializeComponent ();
		}

        async private void addProduct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProducts());
        }
    }
}