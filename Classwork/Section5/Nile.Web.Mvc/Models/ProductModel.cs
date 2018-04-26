using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Web.Mvc.Models
{
    /// <summary>Provides information about a product. </summary>
    public class ProductModel
    {
        
        public int Id { get; set; }
      
        // value tag allows documenting default value if not "0"
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [RangeAttribute(0, Double.MaxValue, ErrorMessage = "Price must be >= 0")]
        public decimal Price { get; set; }

        public bool IsDiscontinued { get; set; }
    }
}
