namespace CourseWork
{
    partial class FormProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.name = new System.Windows.Forms.TextBox();
            this.weight = new System.Windows.Forms.TextBox();
            this.count = new System.Windows.Forms.TextBox();
            this.cost = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.article = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(101, 28);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(279, 20);
            this.name.TabIndex = 0;
            // 
            // weight
            // 
            this.weight.Location = new System.Drawing.Point(101, 54);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(279, 20);
            this.weight.TabIndex = 1;
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(101, 80);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(279, 20);
            this.count.TabIndex = 2;
            // 
            // cost
            // 
            this.cost.Location = new System.Drawing.Point(101, 106);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(279, 20);
            this.cost.TabIndex = 3;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(102, 133);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(136, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Сохранить";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(244, 133);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(136, 23);
            this.cancel.TabIndex = 5;
            this.cancel.Text = "Отменить";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Вес";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Цена";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Артикул:";
            // 
            // article
            // 
            this.article.AutoSize = true;
            this.article.Location = new System.Drawing.Point(98, 9);
            this.article.Name = "article";
            this.article.Size = new System.Drawing.Size(13, 13);
            this.article.TabIndex = 11;
            this.article.Text = "0";
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 174);
            this.Controls.Add(this.article);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.count);
            this.Controls.Add(this.weight);
            this.Controls.Add(this.name);
            this.Name = "FormProduct";
            this.Text = "Product";
            this.Load += new System.EventHandler(this.Product_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox weight;
        private System.Windows.Forms.TextBox count;
        private System.Windows.Forms.TextBox cost;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label article;
    }
}