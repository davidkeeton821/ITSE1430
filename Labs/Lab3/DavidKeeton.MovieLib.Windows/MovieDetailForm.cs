/*
 * David Keeton
 * 3/29/2018
 * Lab3 ITSE 1430
 */

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Linq;

namespace DavidKeeton.MovieLib.Windows
{
    /// <summary>Provides a form for adding/editing <see cref=" Movie"/>.</summary>
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

            //Load Product
            if(Movie != null)
            {
                _textTitle.Text = Movie.Title;
                _textDescription.Text = Movie.Description;
                _textLength.Text = Movie.Length.ToString();
                _chkIsOwned.Checked = Movie.Owned;
            }

            ValidateChildren();
        }

        #region Event Handlers
        private void OnSave( object sender, EventArgs e )
        {
            //Create product
            var movie = new Movie()  {                     
            Title = _textTitle.Text,
            Description = _textDescription.Text,
            Length = ConvertToInt(_textLength),
            Owned = _chkIsOwned.Checked
            };

            //Validate movie using IValidatableObject
            var context = new ValidationContext(movie as IValidatableObject);
            var errors = movie.Validate(context);
            if(errors.Count() > 0)
            {
                //Get first error
                DisplayError(errors.ElementAt(0).ErrorMessage);
                return;
            }

            //Return from form
            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        private void DisplayError( string message )
        {
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private int ConvertToInt( TextBox control )
        {
            if (Int32.TryParse(control.Text, out var length))
                return length;

            return -1;
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
