using CourseWork.Entities;
using System;
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
            if (product.Article == null) return; 
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
            bool flag = product.Article == null;
            product.Name = name.Text;
            product.Weight = double.Parse(weight.Text);
            product.Article = article.Text;
            product.Cost = double.Parse(cost.Text);
            product.Count = int.Parse(count.Text);

            if (flag) 
                MySql.InsertProduct(product); 
            else
                MySql.UpdateProduct(product);
            
            Close();
        }
    }
}
