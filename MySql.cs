using CourseWork.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    class MySql
    {
        private static readonly string cs = @"server=localhost;userid=root;password=;database=course_work";

        private static MySqlConnection sqlConnection;

        private static MySqlConnection GetConnection()
        {
            if (sqlConnection == null) sqlConnection = new MySqlConnection(cs);

            if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

            return sqlConnection;
        }

        public static List<Product> GetProduts()
        {
            var stm = "select * from products";
            var cmd = new MySqlCommand(stm, GetConnection());
            var rdr = cmd.ExecuteReader();
            var products = new List<Product>();
            while (rdr.Read()) products.Add(Product.From(rdr));
            rdr.Close();

            return products;
        }

        public static List<Order> GetOrders()
        {
            var stm = "select * from orders";
            var cmd = new MySqlCommand(stm, GetConnection());
            var rdr = cmd.ExecuteReader();
            var orders = new List<Order>();
            while (rdr.Read()) orders.Add(Order.From(rdr));
            rdr.Close();

            return orders;
        }

        public static void UpdateProduct(Product product)
        {
            var sql = "UPDATE products set name = @name, weight = @weight, count = @count, cost = @cost WHERE article = @article";
            var cmd = new MySqlCommand(sql, GetConnection());
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@weight", product.Weight);
            cmd.Parameters.AddWithValue("@count", product.Count);
            cmd.Parameters.AddWithValue("@cost", product.Cost);
            cmd.Parameters.AddWithValue("@article", product.Article);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void AppendProductCount(Product product)
        {
            var sql = "UPDATE products set count = count + @count WHERE article = @article";
            var cmd = new MySqlCommand(sql, GetConnection());
            cmd.Parameters.AddWithValue("@count", product.Count);
            cmd.Parameters.AddWithValue("@article", product.Article);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void SubtractProductCount(Product product)
        {
            var sql = "UPDATE products set count = count - @count WHERE article = @article";
            var cmd = new MySqlCommand(sql, GetConnection());
            cmd.Parameters.AddWithValue("@count", product.Count);
            cmd.Parameters.AddWithValue("@article", product.Article);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void InsertProduct(Product product)
        {
            var sql = "insert into products (article, name, weight, count, cost) values (@article, @name, @weight, @count, @cost)";
            var cmd = new MySqlCommand(sql, GetConnection());

            cmd.Parameters.AddWithValue("@article", product.Article);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@weight", product.Weight);
            cmd.Parameters.AddWithValue("@count", product.Count);
            cmd.Parameters.AddWithValue("@cost", product.Cost);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void OrderData(Order order)
        {
            var sql = "SELECT p.article, p.name, p.weight, od.count, od.cost from products p inner JOIN orders_data od WHERE p.article = od.product_id and od.order_id = @order_id";
            var cmd = new MySqlCommand(sql, GetConnection());

            cmd.Parameters.AddWithValue("@order_id", order.Id);
            cmd.Prepare();
            var response = cmd.ExecuteReader();
            order.Products = new List<Product>();
            while (response.Read()) order.Products.Add(Product.From(response));
            response.Close();
        }

        public static void insertOrderData(Order order)
        {
            var sql = "insert into orders_data (order_id, product_id, count, cost) values (@order_id, @product_id, @count, @cost)";
            order.Products.ForEach(p => {
                SubtractProductCount(p);
                var cmd = new MySqlCommand(sql, GetConnection());
                cmd.Parameters.AddWithValue("@order_id", order.Id);
                cmd.Parameters.AddWithValue("@product_id", p.Article);
                cmd.Parameters.AddWithValue("@count", p.Count);
                cmd.Parameters.AddWithValue("@cost", p.Cost);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            });
        }
        public static void deleteOrderData(Order order)
        {
            var sql = "delete from orders_data where order_id = @order_id and product_id = @product_id";
            Order old = new Order();
            old.Id = order.Id;
            OrderData(old);
            old.Products.ForEach(p => {
                var cmd = new MySqlCommand(sql, GetConnection());
                cmd.Parameters.AddWithValue("@order_id", order.Id);
                cmd.Parameters.AddWithValue("@product_id", p.Article);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                AppendProductCount(p);
            });
        }

        public static void insertOrder(Order order)
        {
            var sql = "insert into orders (recipient, address, weight, amount) values (@recipient, @address, @weight, @amount)";
            var cmd = new MySqlCommand(sql, GetConnection());
            cmd.Parameters.AddWithValue("@recipient", order.Recipient);
            cmd.Parameters.AddWithValue("@address", order.Address);
            cmd.Parameters.AddWithValue("@weight", order.Weight);
            cmd.Parameters.AddWithValue("@amount", order.Amount);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            order.Id = cmd.LastInsertedId;
            insertOrderData(order);
        } 
        
        public static void updateOrder(Order order)
        {
            var sql = "update orders set recipient = @recipient, address = @address, weight = @weight, amount = @amount where id = @id";
            var cmd = new MySqlCommand(sql, GetConnection());
            cmd.Parameters.AddWithValue("@recipient", order.Recipient);
            cmd.Parameters.AddWithValue("@address", order.Address);
            cmd.Parameters.AddWithValue("@weight", order.Weight);
            cmd.Parameters.AddWithValue("@amount", order.Amount);
            cmd.Parameters.AddWithValue("@id", order.Id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            deleteOrderData(order);
            insertOrderData(order);
        }
    }
}
