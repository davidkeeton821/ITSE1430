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
    /// <summary>Provides a product database.</summary>
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
        public Movie Add( Movie movie, out string message )
        {
            //Check for null
            if(movie == null)
            {
                message = "Movie cannot be null.";
                return null;
            };

            //Verify Unique product
            var existing = GetMovieByName(movie.Title);
            if (existing != null)
            {
                message = "Movie already exists.";
                return null;
            };

            message = null;

            //Clone the object
            movie.Id = _nextId++;
            _movies.Add(Clone(movie));

            //return a copy
            return movie;
        }

        /// <summary>Gets a movie.</summary>
        /// <param name="id">The ID of the movie</param>
        /// <returns>A copy of a movie.</returns>
        public Movie Get( int id )
        {
            //If id is valid, find movie in list and return a copy
            if (id > 0)
            {
                foreach (var movie in _movies)
                {
                    if (movie.Id == id)
                        return Clone(movie);
                };
            }
            return null;           
        }

        /// <summary>Gets a movie.</summary>
        /// <param name="id">The ID of the movie</param>
        /// <returns>The actual instance of a movie.</returns>
        private Movie GetActual( int id )
        {
            //If id is valid, find movie in list and return it
            if (id > 0)
            {
                foreach (var movie in _movies)
                {
                    if (movie.Id == id)
                        return movie;
                };
            }
            return null;
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of all movies.</returns>
        public IEnumerable<Movie> GetAll()
        {
            foreach (var movie in _movies)
            {
                if (movie != null)
                    yield return Clone(movie);
            };
        }

        /// <summary>Removes a movie.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>True if the movie was deleted, and false if not</returns>
        /// <remarks>
        /// Will not attempt delete if <paramref name="id"/> is less than or equal to zero.
        /// </remarks>
        public bool Remove( int id )
        {
            if (id > 0)
            {
                var existing = GetActual(id);
                if (existing != null)
                {
                    _movies.Remove(existing);
                    return true;
                }                      
            };
            return false;
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
        public Movie Update( Movie movie, out string message )
        {
            message = "";   

            //Check for null
            if (movie == null)
            {
                message = "Movie cannot be null.";
                return null;
            };

            //Verify Unique product
            var existing = GetMovieByName(movie.Title);
            if (existing != null && existing.Id != movie.Id)
            {
                message = "Movie already exists.";
                return null;
            };

            //Find Existing
            existing = existing ?? GetActual(movie.Id);
            if (existing == null)
            {
                message = "Movie not found";
                return null;
            }
            Copy(existing, movie);

            return Clone(movie);
        }

        #region Private Members
        //Clone a product
        private Movie Clone( Movie item )
        {
            var newMovie = new Movie();
            Copy(newMovie, item);

            return newMovie;
        }

        //Copy one movie from one object to another
        private void Copy( Movie target, Movie source )
        {
            var newProduct = new Movie();
            target.Id = source.Id;
            target.Title = source.Title;
            target.Description = source.Description;
            target.Length = source.Length;
            target.Owned = source.Owned;
        }

        private Movie GetMovieByName( string title )
        {
            foreach (var movie in _movies)
            {
                //case insensitive comparison
                if (String.Compare(movie.Title, title, true) == 0)
                    return movie;
            };
            return null;
        }

        private readonly List<Movie> _movies = new List<Movie>();
        private int _nextId = 1;
        #endregion
    }
}
