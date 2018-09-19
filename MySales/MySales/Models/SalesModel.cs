using SQLite;


namespace MySales
{
    class SalesModel
    {
            [AutoIncrement, PrimaryKey]
            public int id_sale { get; set; }
            public string date { get; set; }
            public bool pay { get; set; }
            public string customer_name { get; set; }
            public double sale_price { get; set; }
    }
}
