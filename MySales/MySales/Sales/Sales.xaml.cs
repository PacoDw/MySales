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
            this.Appearing += sales_appearing;
        }

        async private void sales_appearing(object sender, EventArgs e)
        {
            lst.ItemsSource = null;
            lst.ItemsSource = await App.MySalesDB.Table<SalesModel>().ToListAsync();
        }

        async private void addSale_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSales());
        }

        private async Task selectSale(object sender, ItemTappedEventArgs e)
        {
            var selectedSale = e.Item as SalesModel;
            var saleDetails = new SaleDetails();
            saleDetails.BindingContext = selectedSale;
            await Navigation.PushAsync(saleDetails);
        }
    }
}