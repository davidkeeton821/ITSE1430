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
    public /*abstract*/ partial class ProductDetailForm : Form
    {
        #region Construction
        public ProductDetailForm()
        {
            InitializeComponent();
        }

        public ProductDetailForm(string title) :this() //: base()
        {
            //InitializeComponent();

            Text = title;
        }

        public ProductDetailForm( Product product ) :this("Edit Product")
        {
            //InitializeComponent();

            //Text = "Edit Product";
            Product = product;
        }
        #endregion

        public Product Product { get; set; }

        //public virtual DialogResult ShowDialogEx()
        //{
        //    return ShowDialog();
        //}

        //public abstract DialogResult ShowDialogEx();

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

            ValidateChildren();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            //DialogResult set to Cancel, no method needed
        }

        private void OnSave( object sender, EventArgs e )
        {
            //***Force validation of child controls***
            if (!ValidateChildren())
                return;

            // Create Product - using object initializer syntax
            var product = new Product() {
            Name = _textName.Text,
            Description = _textDescription.Text,
            Price = ConvertToPrice(_textPrice),
            IsDiscontinued = _chkIsDicsontinued.Checked,
            };

            //Validate
            var message = product.Validate();
            if (!String.IsNullOrEmpty(message))
            { 
                DisplayError(message);
                return;               
            }

            //return from form
            Product = product;
            DialogResult = DialogResult.OK;
            //DialogResult = DialogResult.None;
            Close();
        }

        private void DisplayError (string message)
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private decimal ConvertToPrice (TextBox control)
        {
            if (Decimal.TryParse(control.Text, out var price))
                return price;

            return -1;
        }

        private void _textName_Validating( object sender, CancelEventArgs e )
        {
            var textbox = sender as TextBox;
            if (String.IsNullOrEmpty(textbox.Text))
            {
                _errorProvider.SetError(textbox, "Name is required");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }

        private void _textPrice_Validating( object sender, CancelEventArgs e )
        {
            var textbox = sender as TextBox;
            if (ConvertToPrice(textbox) <= 0)
            {
                _errorProvider.SetError(textbox, "Price must be >= 0");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }
    }
}
