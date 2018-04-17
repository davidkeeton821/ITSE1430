/*
 * David Keeton
 * 3/29/2018
 * Lab3 ITSE 1430
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidKeeton.MovieLib
{
    /// <summary>Provides a movie database.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add</param>
        /// <param name="message">The error message, if any</param>
        /// <returns>The added movie</returns>
        /// <remarks>
        /// Generates an error if:
        /// <paramref name="movie"/> is null or invalid.
        /// A movie with the same name already exists
        /// </remarks>
        public int Add( Movie movie )
        {
            //Check for null
            movie = movie ?? throw new ArgumentNullException(nameof(movie));

            var context = new ValidationContext(movie);
            movie.Validate(context);

            //Verify Unique product
            var existing = GetMovieByTitleCore(movie.Title);
            if (existing != null)
                throw new Exception("Movie Already Exists");

            //return a copy
            return AddCore(movie);
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of all movies.</returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore()
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Id)
                .Select(p => p);
        }

        /// <summary>Removes a movie.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>True if the movie was deleted, and false if not</returns>
        /// <remarks>
        /// Will not attempt delete if <paramref name="id"/> is less than or equal to zero.
        /// </remarks>
        public void Remove( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");
            RemoveCore(id);
        }

        /// <summary>Updates an existing movie in the database.</summary>
        /// <param name="movie">The movie to update.</param>
        /// <param name="message">The error message, if any.</param>
        /// <returns>The updated product.</returns>
        /// <remarks>
        /// Generates an error if:
        /// <paramref name="movie"/>is null or invalid.
        /// A movie with the same name already exists.
        /// The movie does not exist.
        /// </remarks>
        public void Update( Movie movie )
        {
            //Check for null
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var context = new ValidationContext(movie);
            movie.Validate(context);

            //Verify existing product 
            var existing = GetMovieByTitleCore(movie.Title);
            if (existing != null && existing.Id != movie.Id)
                throw new Exception("Another movie has the same name");
            //Find Existing
            existing = existing ?? GetCore(movie.Id);
            if (existing == null)
                throw new ArgumentException("Movie not found", nameof(movie));
                                             
            UpdateCore(movie);
        }

        public Movie GetMovie(int id)
        {
            if (id > 0)
               return GetCore(id);

            return null;
        }

        protected abstract IEnumerable<Movie> GetAllCore();
        protected abstract int AddCore( Movie movie );
        protected abstract Movie GetCore( int id );
        protected abstract void UpdateCore( Movie movie );
        protected abstract void RemoveCore( int id );
        protected abstract Movie GetMovieByTitleCore( string name );
    }
}
