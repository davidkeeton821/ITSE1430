﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nile.Data;
using Nile.Data.IO;
using Nile.Data.Memory;
using Nile.Data.Sql;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            var connString = ConfigurationManager.ConnectionStrings["NileDatabase"];
            //_database = new FileProductDatabase("products.csv");
            _database = new SqlProductDatabase(connString.ConnectionString);

            RefreshUI();
        }

        #region Event Handlers       

        private void OnProductAdd( object sender, EventArgs e )
        {
            var button = sender as ToolStripMenuItem;

            var form = new ProductDetailForm("Add Product");

            //Show form modally
            var result = form.ShowDialog(this); //show child form (ProductRetailForm), return back dailog result
            if (result != DialogResult.OK)  //use dialog result from child form
                return;

            //Add to database
            //_database.Add(form.Product);
            try
            {
                _database.Add(form.Product);
            } catch (NotImplementedException)
            {
                MessageBox.Show("Not Implemented Yet");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //if (!String.IsNullOrEmpty(message))
            //    MessageBox.Show(message);

            RefreshUI();
        }

        private void OnProductRemove( object sender, EventArgs e )
        {
            ///Get selected product
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show(this, "No Product Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            DeleteProduct(product);
        }

        private void DeleteProduct( Product product )
        {
            if (!ShowConfirmation("Are you sure?", "Remove Product"))
                return;

            //Remove product
            try
            {
                _database.Remove(product.Id);
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            RefreshUI();
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            //Get selected product
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show(this, "No Product Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            EditProduct(product);
        }

        private void EditProduct(Product product)
        {
            var form = new ProductDetailForm(product);

            //Show form modally
            var result = form.ShowDialog(this); //show child form (ProductRetailForm), return back dailog result
            if (result != DialogResult.OK)  //use dialog result from child form
                return;

            //Add to database
            form.Product.Id = product.Id;
            try
            {
                _database.Update(form.Product);
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            };

            RefreshUI();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Not Implemented", "Help About", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
#endregion
        private Product GetSelectedProduct ()
        {
            //return (from r in dataGridView1.SelectedRows.OfType<DataGridViewRow>()
            //        select r.DataBoundItem as Product).FirstOrDefault();

            var items = (from r in dataGridView1.SelectedRows.OfType<DataGridViewRow>()
                    select new {
                        Index = r.Index,
                        Product = r.DataBoundItem as Product
                        }).FirstOrDefault();

            return items.Product;
            //if (dataGridView1.SelectedRows.Count > 0)
            //    return dataGridView1.SelectedRows[0].DataBoundItem as Product;

            //return null;
        }

        private void RefreshUI()
        {
            //Get products
            IEnumerable<Product> products = null;
            try
            {
                products = _database.GetAll();
            } catch (Exception)
            {
                MessageBox.Show("Error loading products");
            }

            //Bind to grid
            productBindingSource.DataSource = products?.ToList();
            //dataGridView1.DataSource = new List<Product>(products);
        }

        private bool ShowConfirmation( string message, string title)
        {
            return (MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }
        private void OnCellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;
            EditProduct(product);
        }

        private void OnCellKeyDown( object sender, KeyEventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            if (e.KeyCode == Keys.Delete)
            {              
                    e.Handled = true;
                    DeleteProduct(product);               
            } else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EditProduct(product);
            };

        }

        private IProductDatabase _database;
    }
}
