/*
 * David Keeton
 * 2/23/2018
 * Lab2 ITSE 1430
 */

//TODO failed call to database pops up error in movieDetailForm
//TODO validation in corrrect places in UI/not in UI
//TODO ability to deselect row in datagridview

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
            while (true)
            {
                var result = form.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

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
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show(this, "No Movie Selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            EditMovie(movie);           
        }

        private void EditMovie(Movie movie)
        {
            var form = new MovieDetailForm(movie);
            while (true)
            {
                var result = form.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;

                form.Movie.Id = movie.Id;
                _database.Update(form.Movie, out var message);
                if (!String.IsNullOrEmpty(message))
                    MessageBox.Show(message);
                else
                    break;
            }
            RefreshUI();
        }

        private void OnMoviesDelete( object sender, EventArgs e )
        {
            var movie = GetSelectedMovie();
            if (movie == null)
            {
                MessageBox.Show(this, "No movie to Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            DeleteMovie(movie);
        }

        private void DeleteMovie( Movie movie )
        {
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
                return movieBindingSource.Current as Movie;           
            return null;
        }

        private bool ShowConfirmation( string message, string title )
        {
            return (MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        private void RefreshUI()
        {
            var movies = _database.GetAll();
            movieBindingSource.RaiseListChangedEvents = false;
            movieBindingSource.DataSource = movies.ToList();
            movieBindingSource.RaiseListChangedEvents = true;
            movieBindingSource.ResetBindings(true);
        }



        private void OnCellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            if (e.RowIndex == -1)
                return;
            var movie = GetSelectedMovie();
            if (movie == null)
                return;
            EditMovie(movie);
        }

        private void OnCellKeyDown( object sender, KeyEventArgs e )
        {           
            if(e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                OnMoviesDelete(sender, e);
            }else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                OnMoviesEdit(sender, e);
            };         
        }

        private void dataGridView1_CellClick( object sender, DataGridViewCellEventArgs e )
        {

        }

        private void dataGridView1_Click( object sender, EventArgs e )
        {
            var grid = sender as DataGridView;
            var mouse = e as MouseEventArgs;
            if (grid.Focused == true)
                OnMouseUp(grid, mouse);
        }

        private void OnMouseUp( object sender, MouseEventArgs e )
        {
            var grid = sender as DataGridView;
            if(e.Button == MouseButtons.Left)
            {
                if(grid.HitTest(e.X, e.Y) == DataGridView.HitTestInfo.Nowhere)
                {
                    grid.ClearSelection();
                    grid.CurrentCell = null;
                };
            }               
        }
        private IMovieDatabase _database = new MemoryMovieDatabase();
    }
   
}
