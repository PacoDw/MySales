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
	public partial class Sales : ContentPage
	{
		public Sales ()
		{
            InitializeComponent();
		}


        async private void addSale_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSales());
        }

        private void salesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}