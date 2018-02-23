/*
 * David Keeton
 * 2/23/2018
 * Lab2 ITSE 1430
 */

using System;
using System.Windows.Forms;

namespace DavidKeeton.MovieLib.Windows
{
    public partial class MainForm : Form
    {
        //TODO
        //Each file has a file header.
         
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
            {
                MessageBox.Show(this, "No movie to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
