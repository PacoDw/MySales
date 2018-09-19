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
            this.Appearing += product_appearing;
        }

        async private void product_appearing(object sender, EventArgs e)
        {
            lst.ItemsSource = null;
            lst.ItemsSource = await App.MySalesDB.Table<ProductsModel>().ToListAsync();
        }

        async private void addProduct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProducts());
        }


        private async Task SelectProduct(object sender, ItemTappedEventArgs e)
        {
            if (await DisplayAlert("Information", "What do you want?", "Edit", "Choose"))
            {
                var selectedProduct = e.Item as ProductsModel;
                var productDetails = new ProductDetails();
                productDetails.BindingContext = selectedProduct;
                await Navigation.PushAsync(productDetails);
            }
            else
            {
                var selectedProduct = e.Item as ProductsModel;
                MessagingCenter.Send<Products, ProductsModel>(this, "context", selectedProduct);
                await Navigation.PopAsync(true);
            }
        }
    }
}