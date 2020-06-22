using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CourseWork.Entities
{
    public class Product
    {
        public string Article { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
        
        private Product()
        {

        }

        public static Product From(DataGridViewCellCollection collection)
        {
            if (collection[0].Value == null) return new Product();

            return new Product
            {
                Article = collection[0].Value.ToString(),
                Name = collection[1].Value.ToString(),
                Weight = double.Parse(collection[2].Value.ToString()),
                Count = int.Parse(collection[3].Value.ToString()),
                Cost = double.Parse(collection[4].Value.ToString())
            };
        }

        public static Product From(MySqlDataReader rdr)
        {
            return new Product
            {
                Article = rdr.GetString(0),
                Name = rdr.GetString(1),
                Weight = rdr.GetDouble(2),
                Count = rdr.GetInt32(3),
                Cost = rdr.GetDouble(4)
            };
        }
    }
}
