using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidKeeton.MovieLib
{
    public class Movie
    {   
        public string Title
        {
            get { return _title ?? ""; }
            set { _title = value ?? ""; }
        }

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value ?? ""; }
        }

        public int Length { get; set; } = 0;

        public bool Owned { get; set; }

        private string _title;
        private string _description;
    }
}
