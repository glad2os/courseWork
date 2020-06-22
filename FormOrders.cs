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
    public partial class FormOrders : Form
    {
        private List<Product> products;

        private Order order;

        public FormOrders(Order order)
        {
            this.order = order;
            InitializeComponent();
        }
        
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void FormOrders_Load(object sender, EventArgs e)
        {
            products = MySql.GetProduts();
            products.ForEach(p => comboBox1.Items.Add(p.Name + " (" + p.Article + ")"));
            numericUpDown1.Minimum = 1;

            if (order.Products != null)
                order.Products.ForEach(p => dataGridView1.Rows.Add(p.Article, p.Name, p.Weight, p.Count, p.Cost));

            id.Text = order.Id.ToString();
            recipient.Text = order.Recipient;
            weightLabel.Text = order.Weight.ToString();
            amountLabel.Text = order.Amount.ToString();
            address.Text = order.Address;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = products[comboBox1.SelectedIndex].Count;
        }

        private void Calculate()
        {
            double weight = 0;
            double amount = 0;

            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells[0].Value == null) break;
                weight += double.Parse(item.Cells[2].Value.ToString()) * int.Parse(item.Cells[3].Value.ToString());
                amount += double.Parse(item.Cells[4].Value.ToString()) * int.Parse(item.Cells[3].Value.ToString());
            }

            order.Weight = weight;
            order.Amount = amount;
            weightLabel.Text = weight.ToString();
            amountLabel.Text = amount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = products[comboBox1.SelectedIndex];
            bool flag = false;

            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells[0].Value == null) break;
                if (item.Cells[0].Value.ToString() == p.Article)
                {
                    item.Cells[3].Value = (int.Parse(item.Cells[3].Value.ToString()) + numericUpDown1.Value).ToString();
                    flag = true;
                    break;
                }
            }
            if (!flag) dataGridView1.Rows.Add(p.Article, p.Name, p.Weight, numericUpDown1.Value, p.Cost);
            p.Count -= (int)numericUpDown1.Value;
            numericUpDown1.Maximum = p.Count;
            Calculate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                products.ForEach(p => {
                    if (p.Article == item.Cells[0].Value.ToString())
                    {
                        p.Count += int.Parse(item.Cells[3].Value.ToString());
                        numericUpDown1.Maximum = products[comboBox1.SelectedIndex].Count;
                    }
                });
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            Calculate();
        }

        private void save_Click(object sender, EventArgs e)
        {
            order.Products = new List<Product>();
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (item.Cells[0].Value == null) break;
                order.Products.Add(Product.From(item.Cells));
            }

            bool flag = order.Id == 0;

            order.Recipient = recipient.Text;
            order.Address = address.Text;

            if (flag)
                MySql.insertOrder(order);
            else
                MySql.updateOrder(order);

            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
