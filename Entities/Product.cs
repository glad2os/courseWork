using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork.Entities
{
    public class Product
    {
        private int article;
        private string name;
        private double weight;
        private int count;
        private double cost;

        private Product(int article, string name, double weight, int count, double cost)
        {
            this.article = article;
            this.name = name;
            this.weight = weight;
            this.count = count;
            this.cost = cost;
        }

        public int Article { get => article; set => article = value; }
        public string Name { get => name; set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Count { get => count; set => count = value; }
        public double Cost { get => cost; set => cost = value; }

        public static Product From(DataGridViewCellCollection collection)
        {
            if (collection[0].Value == null) return new Product(0, "", 0, 0, 0);
            return new Product((int) collection[0].Value, (string) collection[1].Value, (double) collection[2].Value, (int) collection[3].Value, (double) collection[4].Value);
        }
    }
}
