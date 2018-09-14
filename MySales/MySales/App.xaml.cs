using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MySales
{
    public partial class App : Application
    {
        // Se hace estatica la base de datos
        static DataBase database;

        // Esta es la que se utilizara
        public static DataBase MySalesDB
        {
            get
            {
                if (database != null)
                    database = new DataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MySalesSQLite.db3"));
                return database;
            }
        }
         
        public App()
        {   
            #if DEBUG
            LiveReload.Init();
            #endif
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
