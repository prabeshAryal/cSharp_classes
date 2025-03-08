namespace EntityFrameworkCW
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            name_tb = new TextBox();
            price_tb = new TextBox();
            category_tb = new TextBox();
            load_btn = new Button();
            insert_btn = new Button();
            update_btn = new Button();
            product_dgv = new DataGridView();
            name_label = new Label();
            price_label = new Label();
            category_label = new Label();
            delete_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)product_dgv).BeginInit();
            SuspendLayout();
            // 
            // name_tb
            // 
            name_tb.Location = new Point(91, 133);
            name_tb.Name = "name_tb";
            name_tb.Size = new Size(100, 23);
            name_tb.TabIndex = 0;
            name_tb.TextChanged += tb_TextChanged;
            // 
            // price_tb
            // 
            price_tb.Location = new Point(91, 162);
            price_tb.Name = "price_tb";
            price_tb.Size = new Size(100, 23);
            price_tb.TabIndex = 1;
            price_tb.TextChanged += tb_TextChanged;

            // 
            // category_tb
            // 
            category_tb.Location = new Point(91, 203);
            category_tb.Name = "category_tb";
            category_tb.Size = new Size(100, 23);
            category_tb.TabIndex = 2;
            category_tb.TextChanged += tb_TextChanged;

            // 
            // load_btn
            // 
            load_btn.Location = new Point(31, 253);
            load_btn.Name = "load_btn";
            load_btn.Size = new Size(75, 23);
            load_btn.TabIndex = 3;
            load_btn.Text = "Load";
            load_btn.UseVisualStyleBackColor = true;
            // 
            // insert_btn
            // 
            insert_btn.Location = new Point(112, 253);
            insert_btn.Name = "insert_btn";
            insert_btn.Size = new Size(75, 23);
            insert_btn.TabIndex = 4;
            insert_btn.Text = "Insert";
            insert_btn.UseVisualStyleBackColor = true;
            insert_btn.Visible=false;
            // 
            // update_btn
            // 
            update_btn.Location = new Point(31, 282);
            update_btn.Name = "update_btn";
            update_btn.Size = new Size(75, 23);
            update_btn.TabIndex = 5;
            update_btn.Text = "Update";
            update_btn.UseVisualStyleBackColor = true;
            update_btn.Visible = false;
            // 
            // product_dgv
            // 
            product_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            product_dgv.Location = new Point(222, 100);
            product_dgv.Name = "product_dgv";
            product_dgv.Size = new Size(554, 246);
            product_dgv.TabIndex = 6;
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Location = new Point(31, 136);
            name_label.Name = "name_label";
            name_label.Size = new Size(39, 15);
            name_label.TabIndex = 7;
            name_label.Text = "Name";
            // 
            // price_label
            // 
            price_label.AutoSize = true;
            price_label.Location = new Point(31, 165);
            price_label.Name = "price_label";
            price_label.Size = new Size(33, 15);
            price_label.TabIndex = 8;
            price_label.Text = "Price";
            // 
            // category_label
            // 
            category_label.AutoSize = true;
            category_label.Location = new Point(30, 206);
            category_label.Name = "category_label";
            category_label.Size = new Size(55, 15);
            category_label.TabIndex = 9;
            category_label.Text = "Category";
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(112, 282);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(75, 23);
            delete_btn.TabIndex = 10;
            delete_btn.Text = "Delete";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(delete_btn);
            Controls.Add(category_label);
            Controls.Add(price_label);
            Controls.Add(name_label);
            Controls.Add(product_dgv);
            Controls.Add(update_btn);
            Controls.Add(insert_btn);
            Controls.Add(load_btn);
            Controls.Add(category_tb);
            Controls.Add(price_tb);
            Controls.Add(name_tb);
            Name = "Form1";
            Text = "Entitty Demo";
            ((System.ComponentModel.ISupportInitialize)product_dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox name_tb;
        private TextBox price_tb;
        private TextBox category_tb;
        private Button load_btn;
        private Button insert_btn;
        private Button update_btn;
        private DataGridView product_dgv;
        private Label name_label;
        private Label price_label;
        private Label category_label;
        private Button delete_btn;
    }
}