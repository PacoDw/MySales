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
	public partial class CustomerDetails : ContentPage
	{
		public CustomerDetails ()
		{
			InitializeComponent ();
		}

        async private void updateCustomer_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning", "Are you sure to update this customer?", "yes", "Cancel"))
            {
                await App.MySalesDB.UpdateAsync(new CustomersModel {
                    id_customer = int.Parse(id_customer.Text),
                    name = name.Text,
                    phone = int.Parse(phone.Text),
                    email = email.Text,
                    comments = comments.Text,
                    picture_customer = picture_customer.Text
                });

                await DisplayAlert("Success!", "The customer has been updated!", "ok");
                await Navigation.PopAsync(true);
            }
        }

        async private void deleteCustomer_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Warning", "Are you sure to delete this customer?", "yes", "Cancel"))
            {
                await App.MySalesDB.DeleteAsync<CustomersModel>(int.Parse(id_customer.Text));
                await DisplayAlert("Success!", "The customer has been deleted!", "ok");
                await Navigation.PopAsync(true);
            }
        }
    }
}