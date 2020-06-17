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

        public static MySqlDataReader GetProduts()
        {
            var stm = "select * from products";
            var cmd = new MySqlCommand(stm, GetConnection());

            return cmd.ExecuteReader();
        }

        public static MySqlDataReader GetOrders()
        {
            var stm = "select * from orders";
            var cmd = new MySqlCommand(stm, GetConnection());

            return cmd.ExecuteReader();
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
        public static void InsertProduct(Product product)
        {
            var sql = "insert into products (name, weight, count, cost) values (@name, @weight, @count, @cost)";
            var cmd = new MySqlCommand(sql, GetConnection());

            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@weight", product.Weight);
            cmd.Parameters.AddWithValue("@count", product.Count);
            cmd.Parameters.AddWithValue("@cost", product.Cost);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }


    }
}
