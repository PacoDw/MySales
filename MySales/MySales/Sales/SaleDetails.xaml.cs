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
	public partial class SaleDetails : ContentPage
	{
        private string _dateTime;

        public SaleDetails ()
		{
			InitializeComponent ();

            this._dateTime = dateSale.Date.ToShortDateString();
        }

        async private void updateSale_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning", "Are you sure to update this sale?", "yes", "Cancel"))
            {
                await App.MySalesDB.UpdateAsync(new SalesModel
                {
                    id_sale = int.Parse(id_sale.Text),
                    date = _dateTime,
                    pay = pay.IsToggled,
                    customer_name = customer_name.Text,
                    sale_price = double.Parse(sale_price.Text)
                });

                await DisplayAlert("Success!", "The sale has been updated!", "ok");
                await Navigation.PopAsync(true);
            }
        }

        async private void deleteSale_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning", "Are you sure to delete this sale?", "yes", "Cancel"))
            {
                await App.MySalesDB.DeleteAsync<SalesModel>(int.Parse(id_sale.Text));
                await DisplayAlert("Success!", "The sale has been deleted!", "ok");
                await Navigation.PopAsync(true);
            }
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            this._dateTime = dateSale.Date.ToShortDateString();
        }
    }
}