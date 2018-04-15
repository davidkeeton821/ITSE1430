/*
 * David Keeton
 * 3/29/2018
 * Lab3 ITSE 1430
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DavidKeeton.MovieLib
{
    /// <summary>Provides information about a Movie</summary>
    public class Movie : IValidatableObject
    {
        /// <summary>Get or sets the movie Id </summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the title</summary>
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

        /// <summary>Determines if the movie is owned</summary>
        public bool Owned { get; set; }

        /// <summary>Validates the movie</summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>Errror message, if any</returns>
        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            //Name is requried
            if (String.IsNullOrEmpty(_title))
                errors.Add(new ValidationResult("Name cannot be empty", new[] { nameof(Title) }));

            //Length > 0
            if (Length < 0)
                errors.Add(new ValidationResult("Length must be >= 0", new[] { nameof(Length) }));

            return errors;
        }

        #region Private Members
        private string _title;
        private string _description;
        #endregion
    }
}
