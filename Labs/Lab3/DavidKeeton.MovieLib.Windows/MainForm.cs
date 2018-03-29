/*
 * David Keeton
 * 3/29/2018
 * Lab3 ITSE 1430
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

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            RefreshUI();
        }

        #region Event Handlers
        //called when a cell is double clicked
        private void OnCellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if (e.RowIndex == -1)
                return;
            var movie = GetSelectedMovie();
            if (movie == null)
                return;
            EditMovie(movie);
        }

        //Called when a key is pressed while in a cell
        private void OnCellKeyDown( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                OnMoviesDelete(sender, e);
            } else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                OnMoviesEdit(sender, e);
            };
        }

        //if click happens and doesn't select anything, deselect currently selected row
        private void OnMouseClick( object sender, EventArgs e )
        {
            var mouse = e as MouseEventArgs;
            var grid = sender as DataGridView;
            if (mouse.Button == MouseButtons.Left)
            {
                if (grid.HitTest(mouse.X, mouse.Y) == DataGridView.HitTestInfo.Nowhere)
                {
                    grid.ClearSelection();
                    grid.CurrentCell = null;
                };
            }
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnMoviesAdd( object sender, EventArgs e )
        {
            var form = new MovieDetailForm("Add Product");
            //if any errors occur, show MovieDetailForm again with same info          
            while (true)
            {
                //Show form modally
                var result = form.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                //Add to database
                _database.Add(form.Movie, out var message);
                if (!String.IsNullOrEmpty(message))
                    MessageBox.Show(message);
                else
                    break;
            }

            RefreshUI();
        }

        private void OnMoviesEdit( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show(this, "No Movie Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            EditMovie(movie);           
        }

        private void OnMoviesDelete( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show(this, "No movie to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            DeleteMovie(movie);
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var form = new AboutForm();

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                return;
        }
        #endregion Event Handlers

        #region Private Members
        //Helper method to handle editing products
        private void EditMovie( Movie movie )
        {
            var form = new MovieDetailForm(movie);
            //if an error occurs, show MovieDetailForm again with same info
            while (true)
            {
                var result = form.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                //Update product
                form.Movie.Id = movie.Id;
                _database.Update(form.Movie, out var message);
                if (!String.IsNullOrEmpty(message))
                    MessageBox.Show(message);
                else
                    break;
            }
            RefreshUI();
        }

        //Helper method to handle deleting products
        private void DeleteMovie( Movie movie )
        {
            if (!ShowConfirmation("Are you sure?", "Delete Movie"))
                return;

            //Remove product
            _database.Remove(movie.Id);

            RefreshUI();
        }

        //Helper method to return movie selected in grid
        private Movie GetSelectedMovie()
        {
            if (dataGridView1.SelectedRows.Count > 0)
                return movieBindingSource.Current as Movie;           
            return null;
        }

        private bool ShowConfirmation( string message, string title )
        {
            return (MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        private void RefreshUI()
        {
            //Get products
            var movies = _database.GetAll();
            //Reset binding of the grid without throwing events
            movieBindingSource.RaiseListChangedEvents = false;
            movieBindingSource.DataSource = movies.ToList();
            movieBindingSource.RaiseListChangedEvents = true;
            movieBindingSource.ResetBindings(true);
        }

        private IMovieDatabase _database = new MemoryMovieDatabase();
        #endregion
    }
}
