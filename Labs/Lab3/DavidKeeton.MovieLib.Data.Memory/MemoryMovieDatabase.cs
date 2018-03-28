using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidKeeton.MovieLib.Data.Memory
{
    public class MemoryMovieDatabase : IMovieDatabase
    {
        public Movie Add( Movie movie, out string message )
        {
            if(movie == null)
            {
                message = "Movie cannot be null.";
                return null;
            };

            //?????????
            var errors = movie.Validate(new ValidationContext(movie));

            var error = errors.FirstOrDefault();
            if (error != null)
            {
                message = error.ErrorMessage;
                return null;
            }

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

        public Movie Get( int id )
        {
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

        private Movie GetActual( int id )
        {
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
        public IEnumerable<Movie> GetAll()
        {
            foreach (var movie in _movies)
            {
                if (movie != null)
                    yield return Clone(movie);
            };
        }

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
        public Movie Update( Movie movie, out string message )
        {
            message = "";   
            if (movie == null)
            {
                message = "Movie cannot be null.";
                return null;
            };

            //Validation
            var context = new ValidationContext(movie as IValidatableObject);
            var errors = movie.Validate(context);
            if (errors.Count() > 0)
            {
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            }

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

        private Movie Clone( Movie item )
        {
            var newMovie = new Movie();
            Copy(newMovie, item);

            return newMovie;
        }

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
    }
}
