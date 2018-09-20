using Microcharts;
using SkiaSharp;
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
	public partial class Graphics : ContentPage
	{
        public Graphics()
        {
            InitializeComponent();
        }

        async protected override void OnAppearing()
        {
            base.OnAppearing();

            int countCustomer = await App.MySalesDB.Table<CustomersModel>().CountAsync();
            int countProduct = await App.MySalesDB.Table<ProductsModel>().CountAsync();

            var entries = new[]
            {
                new Microcharts.Entry(countCustomer)
                {
                    Label = "Customers",
                    ValueLabel = countCustomer.ToString(),
                    Color = SKColor.Parse("#266489")
                },
                new Microcharts.Entry(countProduct )
                {
                    Label = "Products",
                    ValueLabel = countProduct .ToString(),
                    Color = SKColor.Parse("#68B9C0")
                }
            };

            var chart = new BarChart() { Entries = entries };

            this.chartView.Chart = chart;
        }
    }
}