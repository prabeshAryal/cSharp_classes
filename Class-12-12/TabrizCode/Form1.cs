using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace EntityFrameworkCW
{
    public partial class Form1 : Form
    {
        private int _selectedProductId;

        public Form1()
        {
            InitializeComponent();
            // Attach event handlers
            load_btn.Click += Load_btn_Click;
            insert_btn.Click += Insert_btn_Click;
            product_dgv.CellClick += Product_dgv_CellClick;
            update_btn.Click += Update_btn_Click;
            delete_btn.Click += Delete_btn_Click;

        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            insert_btn.Visible = true;
        }

        private void Load_btn_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void Insert_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = name_tb.Text;
                decimal price = decimal.Parse(price_tb.Text);
                string category = category_tb.Text;

                using (var context = new MyDbContext())
                {
                    var newProduct = new Product
                    {
                        Name = name,
                        Price = price,
                        Category = category
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();
                }

                MessageBox.Show("Product inserted successfully!");
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (_selectedProductId > 0)
            {
                try
                {
                    string name = name_tb.Text;
                    decimal price = decimal.Parse(price_tb.Text);
                    string category = category_tb.Text;

                    using (var context = new MyDbContext())
                    {
                        var product = context.Products.FirstOrDefault(p => p.Id == _selectedProductId);
                        if (product != null)
                        {
                            product.Name = name;
                            product.Price = price;
                            product.Category = category;

                            context.SaveChanges();
                            MessageBox.Show("Product updated successfully!");
                            LoadProducts();
                        }
                        else
                        {
                            MessageBox.Show("Product not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to update.");
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (_selectedProductId > 0)
            {
                try
                {
                    using (var context = new MyDbContext())
                    {
                        var product = context.Products.FirstOrDefault(p => p.Id == _selectedProductId);

                        if (product != null)
                        {
                            context.Products.Remove(product);
                            context.SaveChanges();
                            MessageBox.Show("Product deleted successfully!");

                            // Refresh the product list in the DataGridView
                            LoadProducts();
                        }
                        else
                        {
                            MessageBox.Show("Product not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void Product_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            update_btn.Visible = true;
            delete_btn.Visible = true;
            if (e.RowIndex >= 0)
            {
                _selectedProductId = Convert.ToInt32(product_dgv.Rows[e.RowIndex].Cells["Id"].Value);
                name_tb.Text = product_dgv.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                price_tb.Text = product_dgv.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                category_tb.Text = product_dgv.Rows[e.RowIndex].Cells["Category"].Value.ToString();
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var products = context.Products.ToList();
                    product_dgv.DataSource = products;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

      
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyConStr") { }
        public DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}