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
	public partial class AddSales : ContentPage
	{
		public AddSales ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<Customers, CustomersModel>(this, "context", (sender, arg) => {
                this.BindingContext = arg;
            });
        }

        private void saveSale_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Test", "Save a Sale", "ok");
        }

        async private void addCustomer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Customers());
        }

        async private void addProduct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Products());
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {

        }
    }
}