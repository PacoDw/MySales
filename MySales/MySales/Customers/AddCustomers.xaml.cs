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

        private string _picture_customer;

        public AddCustomers ()
		{
			InitializeComponent ();
		}

        private void saveCustomer_Clicked(object sender, EventArgs e)
        {
            var newCustomer = new CustomersModel
            {
                name = name.Text,
                phone = int.Parse(phone.Text),
                email = email.Text,
                comments = comments.Text,
                picture_customer = _picture_customer
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

            _picture_customer = file.Path;
            picture_customer.Source = file.Path;
        }
    }
}