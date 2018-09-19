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
	public partial class Options : ContentPage
	{
		public Options ()
		{
			InitializeComponent ();

            productsButton.Clicked += (sender, args) =>
            {
                Navigation.PushAsync(new Products());

            };

            customersButton.Clicked += (sender, args) =>
            {
                Navigation.PushAsync(new Customers());
            };
        }
    }
}