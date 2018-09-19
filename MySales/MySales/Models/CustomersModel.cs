using SQLite;


namespace MySales
{
    class CustomersModel
    {
        [AutoIncrement, PrimaryKey]
        public int id_customer { get; set; }
        public string customer_name { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string comments { get; set; }
        public string customer_picture { get; set; }
    }
}
