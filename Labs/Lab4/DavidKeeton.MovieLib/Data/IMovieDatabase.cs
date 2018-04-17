/*
 * David Keeton
 * 3/29/2018
 * Lab3 ITSE 1430
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidKeeton.MovieLib
{
    /// <summary>Povides access to movies.</summary>
    public interface IMovieDatabase
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
        int Add( Movie movie);   

        ///// <summary>Gets a movie.</summary>
        ///// <param name="id">The ID of the movie</param>
        ///// <returns>A movie.</returns>
        //Movie Get( int id );

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of all movies.</returns>
        IEnumerable<Movie> GetAll();

        /// <summary>Removes a movie.</summary>
        /// <param name="id">The ID of the movie.</param>
        /// <returns>True if the movie was deleted, and false if not</returns>
        /// <remarks>
        /// Will not attempt delete if <paramref name="id"/> is less than or equal to zero.
        /// </remarks>
        void Remove( int id );

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
        void Update( Movie movie);
    }
}
