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
	public partial class ProductDetails : ContentPage
	{
		public ProductDetails ()
		{
			InitializeComponent ();
		}

        async private void updateProduct_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning", "Are you sure to update this product?", "yes", "Cancel"))
            {
                await App.MySalesDB.UpdateAsync(new ProductsModel
                {
                    id_product = int.Parse(id_product.Text),
                    product_name = product_name.Text,
                    sale_price = double.Parse(sale_price.Text),
                    count = int.Parse(count.Text),
                    cost_price = double.Parse(cost_price.Text),
                    product_picture = product_picture.Text
                });

                await DisplayAlert("Success!", "The product has been updated!", "ok");
                await Navigation.PopAsync(true);
            }
        }

        async private void deleteProduct_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning", "Are you sure to delete this product?", "yes", "Cancel"))
            {
                await App.MySalesDB.DeleteAsync<ProductsModel>(int.Parse(id_product.Text));
                await DisplayAlert("Success!", "The product has been deleted!", "ok");
                await Navigation.PopAsync(true);
            }
        }
    }
}