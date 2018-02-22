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

            //TODO: Validation
        }

        private void OnSave( object sender, EventArgs e )
        {
            //TODO: Validation

            var movie = new Movie();
            movie.Title = _textTitle.Text;
            movie.Description = _textDescription.Text;
            movie.Length = ConvertToInt(_textLength);
            movie.Owned = _chkIsOwned.Checked;

            //TODO: VAlidation

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
    }
}
