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
	public partial class AddCustomers : ContentPage
	{

        private string _customer_picture;

        public AddCustomers ()
		{
			InitializeComponent ();
		}

        private void saveCustomer_Clicked(object sender, EventArgs e)
        {
            var newCustomer = new CustomersModel
            {
                customer_name = customer_name.Text,
                phone = int.Parse(phone.Text),
                email = email.Text,
                comments = comments.Text,
                customer_picture = _customer_picture
            };
            App.MySalesDB.InsertAsync(newCustomer);
            DisplayAlert("Success!", "The customer was added!", "ok");

            Navigation.PopAsync(true);
        }

        async private void takePictureCustomer_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MySales Pictures",
                Name = "image.jpg",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 25,
            });

            if (file == null)
                return;

            _customer_picture = file.Path;
            customer_picture.Source = file.Path;
        }
    }
}