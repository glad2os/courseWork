using CourseWork.Entities;
using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            MySql.GetOrders().ForEach(o => dataGridView1.Rows.Add(o.Id, o.Recipient,
                o.Address, o.Weight, o.Amount));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();

            Form2 form2 = new Form2();
            form2.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellCollection cells = dataGridView1.Rows[e.RowIndex].Cells;

            FormOrders formOrders = new FormOrders(Order.From(cells));
            formOrders.ShowDialog();
            refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
