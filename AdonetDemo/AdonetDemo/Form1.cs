namespace AdonetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

            ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = txtName.Text,
                StockAmount = Convert.ToInt32(txtStockAmount.Text),
                UnitPrice = Convert.ToDecimal(txtUnitPrice.Text)
        });
            LoadProducts();
            MessageBox.Show("Product Add");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbtName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbtUnitPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbtStockAmount.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbtName.Text,
                UnitPrice = Convert.ToDecimal(tbtUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbtStockAmount.Text),
            };
            _productDal.Update(product);
            LoadProducts();
            MessageBox.Show("Product Updated!");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value);
            _productDal.Delete(id);
            LoadProducts();
            MessageBox.Show("Product Deleted!");
        }
    }
}