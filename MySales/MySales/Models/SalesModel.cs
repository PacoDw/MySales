using SQLite;


namespace MySales
{
    class SalesModel
    {
            [AutoIncrement, PrimaryKey]
            public int id_sale { get; set; }
            public string date { get; set; }
            public bool pay { get; set; }
            [Indexed]
            public int id_customer { get; set; }
            [Indexed]
            public int id_product { get; set; }
    }
}
