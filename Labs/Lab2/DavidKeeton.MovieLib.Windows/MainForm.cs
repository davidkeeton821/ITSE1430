using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DavidKeeton.MovieLib.Windows
{
    public partial class MainForm : Form
    {
        //TODO
        //Adding a movie validates the data.
        //Editing when no movie exists displays an error.
        //Each file has a file header.
        //Public types and members have doctags.
        // 
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnMoviesAdd( object sender, EventArgs e )
        {
            var form = new MovieDetailForm("Add Product");

            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            _movie = form.Movie;
        }

        private void OnMoviesEdit( object sender, EventArgs e )
        {
            if (_movie == null)
                return;

            var form = new MovieDetailForm(_movie);

            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            _movie = form.Movie;
        }

        private void OnMoviesDelete( object sender, EventArgs e )
        {
            if (ShowConfirmation("Are you sure?", "Delete Movie"))
                _movie = null;
            return;
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var form = new AboutForm();

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                return;
        }

        private bool ShowConfirmation( string message, string title )
        {
            return (MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        private Movie _movie;
    }
}
