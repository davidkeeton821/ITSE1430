using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLib.Web.Mvc.Models
{
    public class MovieViewModel
    {       
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Length must be >= 0")]
        public int Length { get; set; }

        public bool Owned { get; set; }
    }
}