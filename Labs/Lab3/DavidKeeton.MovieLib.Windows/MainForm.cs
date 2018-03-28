/*
 * David Keeton
 * 2/23/2018
 * Lab2 ITSE 1430
 */

using System;
using System.Linq;
using System.Windows.Forms;
using DavidKeeton.MovieLib.Data.Memory;

namespace DavidKeeton.MovieLib.Windows
{
    public partial class MainForm : Form
    {        
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

            _database.Add(form.Movie, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);

            RefreshUI();
        }

        private void OnMoviesEdit( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show(this, "No movie to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            var form = new MovieDetailForm(movie);

            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            form.Movie.Id = movie.Id;
            _database.Update(form.Movie, out var message);
            if (!String.IsNullOrEmpty(message))
                MessageBox.Show(message);

            RefreshUI();
        }

        private void OnMoviesDelete( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show(this, "No movie to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            if (!ShowConfirmation("Are you sure?", "Delete Movie"))
                return;

            _database.Remove(movie.Id);

            RefreshUI();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var form = new AboutForm();

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                return;
        }

        private Movie GetSelectedMovie()
        {
            if (dataGridView1.SelectedRows.Count > 0)
                return dataGridView1.SelectedRows[0].DataBoundItem as Movie;

            return null;
        }

        private bool ShowConfirmation( string message, string title )
        {
            return (MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        private void RefreshUI()
        {
            var movies = _database.GetAll();

            movieBindingSource.DataSource = movies.ToList();
        }

        private IMovieDatabase _database = new MemoryMovieDatabase();
    }
}
