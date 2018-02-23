/*
 * David Keeton
 * 2/23/2018
 * Lab2 ITSE 1430
 */

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DavidKeeton.MovieLib.Windows
{
    /// <summary>Gives information on a MovieDetailForm</summary>
    public partial class MovieDetailForm : Form
    {

        #region Construction
        public MovieDetailForm()
        {
            InitializeComponent();
        }

        public MovieDetailForm(string title) :this()
        {
            Text = title;
        }

        public MovieDetailForm( Movie movie ) : this("Edit Movie")
        {
            Movie = movie;
        }
        #endregion

        /// <summary>Gets and sets the movie property</summary>
        public Movie Movie { get; set; }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            if(Movie != null)
            {
                _textTitle.Text = Movie.Title;
                _textDescription.Text = Movie.Description;
                _textLength.Text = Movie.Length.ToString();
                _chkIsOwned.Checked = Movie.Owned;
            }

            ValidateChildren();
        }

        private void OnSave( object sender, EventArgs e )
        {
            if(!ValidateChildren())
                return;

            var movie = new Movie();
            movie.Title = _textTitle.Text;
            movie.Description = _textDescription.Text;
            movie.Length = ConvertToInt(_textLength);
            movie.Owned = _chkIsOwned.Checked;

            //Validation
            var message = movie.Validate();
            if(!String.IsNullOrEmpty(message))
            {
                DisplayError(message);
                return;
            }

            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        private int ConvertToInt( TextBox control )
        {
            if (Int32.TryParse(control.Text, out var price))
                return price;

            return -1;
        }

        private void DisplayError( string message )
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _textTitle_Validating( object sender, CancelEventArgs e )
        {
            var textbox = sender as TextBox;
            if (String.IsNullOrEmpty(textbox.Text))
            {
                _errorProvider.SetError(textbox, "Title is required");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }

        private void _textLength_Validating( object sender, CancelEventArgs e )
        {
            var textbox = sender as TextBox;
            if (ConvertToInt(textbox) <= 0)
            {
                _errorProvider.SetError(textbox, "Length must be >= 0");
                e.Cancel = true;
            } else
                _errorProvider.SetError(textbox, "");
        }
    }
}
