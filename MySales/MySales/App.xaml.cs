using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MySales
{
    public partial class App : Application
    {
        // Se hace estatica la base de datos
        static SQLiteAsyncConnection database;

        // Esta es la que se utilizara
        public static SQLiteAsyncConnection MySalesDB
        {
            get
            {
                //if (database != null)
                //{
                    database = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MySalesSQLite.db3"));
                    database.CreateTableAsync<ProductsModel>().Wait();
                    database.CreateTableAsync<SalesModel>().Wait();
                    database.CreateTableAsync<CustomersModel>().Wait();
                //}
                return database;
            }
        }
         
        public App()
        {
            //#if DEBUG
            //LiveReload.Init();
            //#endif
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
