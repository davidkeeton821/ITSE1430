///*
// * David Keeton
// * 3/29/2018
// * Lab3 ITSE 1430
// */

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DavidKeeton.MovieLib.Data.Memory
//{
//    /// <summary>Provides an in-memory product database.</summary>
//    public class MemoryMovieDatabase : MovieDatabase
//    {
//        /// <summary>Adds a movie to the database.</summary>
//        /// <param name="movie">The movie to add</param>
//        /// <param name="message">The error message, if any</param>
//        /// <returns>The added movie</returns>
//        /// <remarks>
//        /// Generates an error if:
//        /// <paramref name="movie"/> is null or invalid.
//        /// A movie with the same name already exists
//        /// </remarks>
//        protected override Movie AddCore( Movie movie)
//        {
            
//            //Clone the object
//            movie.Id = _nextId++;
//            _movies.Add(Clone(movie));

//            //return a copy
//            return movie;
//        }

//        /// <summary>Gets a movie.</summary>
//        /// <param name="id">The ID of the movie</param>
//        /// <returns>A copy of a movie.</returns>
//        protected override Movie GetCore( int id )
//        {
//            return(from m in _movies
//                   where m.Id == id
//                   select m).FirstOrDefault();
//        }

//        /// <summary>Gets all the movies.</summary>
//        /// <returns>The list of all movies.</returns>
//        protected override IEnumerable<Movie> GetAllCore()
//        {
//            return from m in _movies
//                   select Clone(m);
//        }

//        /// <summary>Removes a movie.</summary>
//        /// <param name="id">The ID of the movie.</param>
//        /// <returns>True if the movie was deleted, and false if not</returns>
//        /// <remarks>
//        /// Will not attempt delete if <paramref name="id"/> is less than or equal to zero.
//        /// </remarks>
//        protected override void RemoveCore( int id )
//        {
//                var existing = GetCore(id);
//                if (existing != null)
//                    _movies.Remove(existing);                                    
//        }

//        /// <summary>Updates an existing movie in the database.</summary>
//        /// <param name="movie">The movie to update.</param>
//        /// <param name="message">The error message, if any.</param>
//        /// <returns>The updated product.</returns>
//        /// <remarks>
//        /// Generates an error if:
//        /// <paramref name="movie"/>is null or invalid.
//        /// A movie with the same name already exists.
//        /// The movie does not exist.
//        /// </remarks>
//        protected override Movie UpdateCore( Movie movie)
//        {
//            //Verify Unique product
//            var existing = GetCore(movie.Id);

//            Copy(existing, movie);

//            return movie;
//        }

//        protected override Movie GetMovieByTitleCore( string title )
//        {
//            return (from m in _movies
//                    where String.Compare(m.Title, title, true) == 0
//                    select m).FirstOrDefault();
//        }

//        #region Private Members
//        //Clone a product
//        private Movie Clone( Movie item )
//        {
//            var newMovie = new Movie();
//            Copy(newMovie, item);

//            return newMovie;
//        }

//        //Copy one movie from one object to another
//        private void Copy( Movie target, Movie source )
//        {
//            var newProduct = new Movie();
//            target.Id = source.Id;
//            target.Title = source.Title;
//            target.Description = source.Description;
//            target.Length = source.Length;
//            target.Owned = source.Owned;
//        }



//        private readonly List<Movie> _movies = new List<Movie>();
//        private int _nextId = 1;
//        #endregion
//    }
//}
