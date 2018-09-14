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

namespace MySales
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection database;

        public DataBase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<ProductsModel>().Wait();
            database.CreateTableAsync<SalesModel>().Wait();
            database.CreateTableAsync<CustomersModel>().Wait();
        }

    }
}
