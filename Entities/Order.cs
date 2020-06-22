using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CourseWork.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public string Recipient { get; set; }
        public string Address { get; set; }
        public double Weight { get; set; }
        public double Amount { get; set; }
        public List<Product> Products { get; set; }

        public Order()
        {
            Id = 0;
        }

        public static Order From(DataGridViewCellCollection collection)
        {
            if (collection[0].Value == null) return new Order();
            Order order = new Order
            {
                Id = (long)collection[0].Value,
                Recipient = (string)collection[1].Value,
                Address = (string)collection[2].Value,
                Weight = (double)collection[3].Value,
                Amount = (double)collection[4].Value
            };
            MySql.OrderData(order);
            return order;
        }
        public static Order From(MySqlDataReader rdr)
        {
            return new Order
            {
                Id = rdr.GetInt64(0),
                Recipient = rdr.GetString(1),
                Address = rdr.GetString(2),
                Weight = rdr.GetDouble(3),
                Amount = rdr.GetDouble(4)
            };
        }
    }
}
