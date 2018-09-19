using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace MySales
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddProducts : ContentPage
	{

        private string _product_picture;

        public AddProducts ()
		{
			InitializeComponent ();
		}

        private void saveProduct_Clicked(object sender, EventArgs e)
        {
            var newProduct = new ProductsModel
            {
                product_name = product_name.Text,
                sale_price = double.Parse(sale_price.Text),
                count = int.Parse(count.Text),
                cost_price = double.Parse(cost_price.Text),
                description = description.Text,
                product_picture = _product_picture
            };
            App.MySalesDB.InsertAsync(newProduct);
            DisplayAlert("Success!", "The customer was added!", "ok");

            Navigation.PopAsync(true);
        }

        async private void takePictureProduct_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 25,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
            });

            if (file == null)
                return;

            _product_picture = file.Path;
            product_picture.Source = file.Path;
        }
    }
}