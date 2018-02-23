/*
 * David Keeton
 * 2/23/2018
 * Lab2 ITSE 1430
 */

using System;

namespace DavidKeeton.MovieLib
{
    /// <summary>Provides information about a Movie</summary>
    public class Movie
    {
        /// <summary>Gets or set the title</summary>
        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value ?? ""; }
        }

        /// <summary>Gets or sets the description</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value ?? ""; }
        }

        /// <summary>Gets or sets the length</summary>
        public int Length { get; set; } = 0;

        /// <summary>Gets or sets true or false if movie is owned</summary>
        public bool Owned { get; set; }

        /// <summary>Validates the movie</summary>
        /// <returns>Errror message, if any</returns>
        public string Validate()
        {
            //Title is required
            if (String.IsNullOrEmpty(_title))
                return "Title cannot be empty";
            if (Length < 0)
                return "Length must be >= 0";
            return "";
        }

        private string _title;
        private string _description;
    }
}
