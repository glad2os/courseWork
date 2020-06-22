using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CourseWork.Entities;
using MySql.Data.MySqlClient;
namespace CourseWork
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            MySql.GetProduts().ForEach(p => dataGridView1.Rows.Add(p.Article, p.Name, 
                p.Weight, p.Count, p.Cost));
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellCollection cells = dataGridView1.Rows[e.RowIndex].Cells;

            FormProduct formProduct = new FormProduct(Product.From(cells));
            formProduct.ShowDialog();
            refresh();
        }
    }
}
