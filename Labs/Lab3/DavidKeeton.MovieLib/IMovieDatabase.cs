using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidKeeton.MovieLib
{
    public interface IMovieDatabase
    {
        Movie Add( Movie movie, out string message );       
        Movie Get( int id );
        IEnumerable<Movie> GetAll();
        bool Remove( int id );
        Movie Update( Movie movie, out string message );
    }
}
