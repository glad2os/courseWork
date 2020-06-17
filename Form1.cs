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

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlDataReader rdr = MySql.GetOrders();
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(rdr.GetInt32(0), rdr.GetString(1),
                    rdr.GetString(2), rdr.GetDouble(3), rdr.GetDouble(4));
            }
            rdr.Close();

            Form2 form2 = new Form2();
            form2.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex);
            DataGridViewCellCollection cells = dataGridView1.Rows[e.RowIndex].Cells;

            MessageBox.Show(messageBoxCS.ToString(), "CellMouseDoubleClick Event");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
