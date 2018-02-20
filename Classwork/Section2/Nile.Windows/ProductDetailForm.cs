using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nile.Windows
{
    public partial class ProductDetailForm : Form
    {
        public ProductDetailForm()
        {
            InitializeComponent();
        }

        public Product Product { get; set; }

        //Type override, then onload, method autogenerates
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            //Load Product
            if (Product != null)
            {
                _textName.Text = Product.Name;
                _textDescription.Text = Product.Description;
                _textPrice.Text = Product.Price.ToString();
                _chkIsDicsontinued.Checked = Product.IsDiscontinued;
            }
        }

        private void OnCancel( object sender, EventArgs e )
        {
            //DialogResult set to Cancel, no method needed
        }

        private void OnSave( object sender, EventArgs e )
        {
            // Create Product
            var product = new Product();
            product.Name = _textName.Text;
            product.Description = _textDescription.Text;
            product.Price = ConvertToPrice(_textPrice);
            product.IsDiscontinued = _chkIsDicsontinued.Checked;

            //return from form
            Product = product;
            DialogResult = DialogResult.OK;
            //DialogResult = DialogResult.None;
            Close();
        }

        private decimal ConvertToPrice (TextBox control)
        {
            if (Decimal.TryParse(control.Text, out var price))
                return price;

            return -1;
        }
    }
}
