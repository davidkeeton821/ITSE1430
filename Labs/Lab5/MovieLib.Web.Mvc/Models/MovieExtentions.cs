using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DavidKeeton.MovieLib;

namespace MovieLib.Web.Mvc.Models
{
    public static class MovieExtentions
    {
        public static MovieViewModel ToModel( this Movie source )
                    => new MovieViewModel() {
                        Id = source.Id,
                        Title = source.Title,
                        Description = source.Description,
                        Length = source.Length,
                        Owned = source.Owned
                    };

        public static Movie ToDomain( this MovieViewModel source )
                    => new Movie() {
                        Id = source.Id,
                        Title = source.Title,
                        Description = source.Description,
                        Length = source.Length,
                        Owned = source.Owned
                    };
    }
}