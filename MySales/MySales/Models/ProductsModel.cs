using SQLite;

namespace MySales
{
    class ProductsModel
    {
            [AutoIncrement, PrimaryKey]
            public int id_product { get; set; }
            public string name { get; set; }
            public double sale_price { get; set; }
            public int count { get; set; }
            public double cost_price { get; set; }
            public string description { get; set; }
            public string image { get; set; }
    }
}
