/*
 * David Keeton
 * 3/29/2018
 * Lab3 ITSE 1430
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using DavidKeeton.MovieLib.Data;
using DavidKeeton.MovieLib.Data.Sql;

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

            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            _database = new SqlMovieDatabase(connString.ConnectionString);

            RefreshUI();
        }

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
            //var mouse = e as MouseEventArgs;
            //var grid = sender as DataGridView;
            //if (mouse.Button == MouseButtons.Left)
            //{
            //    if (grid.HitTest(mouse.X, mouse.Y) == DataGridView.HitTestInfo.Nowhere)
            //    {
            //        grid.ClearSelection();
            //        grid.CurrentCell = null;
            //    };
            //}
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnMoviesAdd( object sender, EventArgs e )
        {
            var form = new MovieDetailForm("Add Movie");            

            //Show form modally
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //Add to database
            try
            {
                _database.Add(form.Movie);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        //Helper method to handle editing products
        private void EditMovie( Movie movie )
        {
            var form = new MovieDetailForm(movie);
            //if an error occurs, show MovieDetailForm again with same info
            var result = form.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            //Update product
            form.Movie.Id = movie.Id;
            try
            {
                _database.Update(form.Movie);
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            };
        
            RefreshUI();
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

        //Helper method to handle deleting products
        private void DeleteMovie( Movie movie )
        {
            if (!ShowConfirmation("Are you sure?", "Delete Movie"))
                return;

            //Remove product
            try
            {
                _database.Remove(movie.Id);
            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            RefreshUI();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            var form = new AboutForm();

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                return;
        }

        //Helper method to return movie selected in grid
        private Movie GetSelectedMovie()
        {
                var items = (from r in dataGridView1.SelectedRows.OfType<DataGridViewRow>()
                             select new {
                                 Index = r.Index,
                                 Movie = r.DataBoundItem as Movie
                             }).FirstOrDefault();

                return items.Movie;
        }

        private bool ShowConfirmation( string message, string title )
        {
            return (MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        private void RefreshUI()
        {
            //Get movies
            IEnumerable<Movie> movies = null;
            try
            {
                movies = _database.GetAll();
            } catch (Exception)
            {
                MessageBox.Show("Error loading movies");
            }
            //Reset binding of the grid without throwing events
            movieBindingSource.DataSource = movies?.ToList();
        }

        private IMovieDatabase _database;       
    }
}
