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
        private string _dateTime;

		public AddSales ()
		{
			InitializeComponent ();

            this._dateTime = dateSale.Date.ToShortDateString();

            MessagingCenter.Subscribe<Customers, CustomersModel>(this, "context", (sender, arg) => {
                customer_picture.Source = arg.customer_picture;
                customer_name.Text = arg.customer_name;
                id_customer.Text = arg.id_customer.ToString();
            });

            MessagingCenter.Subscribe<Products, ProductsModel>(this, "context", (sender, arg) => {
                product_picture.Source = arg.product_picture;
                product_name.Text = arg.product_name;
                sale_price.Text = arg.sale_price.ToString();
                id_product.Text = arg.id_product.ToString();
            });
        }

        private void saveSale_Clicked(object sender, EventArgs e)
        {
            var newSale = new SalesModel
            {
                date = _dateTime,
                pay = paid.IsEnabled,
                customer_name = customer_name.Text,
                sale_price = double.Parse(sale_price.Text)
            };
            App.MySalesDB.InsertAsync(newSale);
            DisplayAlert("Success!", "The sale was added!", "ok");

            Navigation.PopAsync(true);
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
            this._dateTime = dateSale.Date.ToShortDateString();
        }
    }
}