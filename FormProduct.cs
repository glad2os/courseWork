using CourseWork.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class FormProduct : Form
    {
        private Product product;

        public FormProduct(Product product)
        {
            this.product = product;
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            name.Text = product.Name;
            article.Text = product.Article.ToString();
            weight.Text = product.Weight.ToString();
            count.Text = product.Count.ToString();
            cost.Text = product.Cost.ToString();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            product.Name = name.Text;
            product.Weight = double.Parse(weight.Text);
            product.Cost = double.Parse(cost.Text);
            product.Count = int.Parse(count.Text);

            if (product.Article == 0) 
                MySql.InsertProduct(product); 
            else
                MySql.UpdateProduct(product);
            
            Close();
        }
    }
}
