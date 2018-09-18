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
	public partial class Customers : ContentPage
	{
		public Customers ()
		{
			InitializeComponent ();
            this.Appearing += customer_appearing;
        }

        async private void customer_appearing(object sender, EventArgs e)
        {
            lst.ItemsSource = null;
            lst.ItemsSource = await App.MySalesDB.Table<CustomersModel>().ToListAsync();
        }

        async private void addCustomer_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCustomers());
        }

        private async Task SelectCustomer(object sender, ItemTappedEventArgs e)
        {
            await DisplayAlert("Detail customer", "Detail customer", "ok");
            //var selectedCustomer = e.Item as CustomersModel;
            //var detailCustomer = new DetailCustomer();
            //detailCustomer.BindingContext = selectedCustomer;
            //await Navigation.PushAsync(detailCustomer);
        }
    }
}