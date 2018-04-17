using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Provides information about a product. </summary>
    public class Product : IValidatableObject
    {
        internal decimal DiscountPercentage = 0.10M;
        /// <summary>Gets or sets the product ID.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value></value>
        // value tag allows documenting default value if not "0"
        public string Description
        {
            get => _description ?? "";
            set => _description = value ?? "";
        }

        /// <summary>Gets or sets the name.</summary>
        [Required(AllowEmptyStrings = false)]
        //[StringLength(1)]
        public string Name
        {
            get => _name ?? "";
            set => _name = value;
        }

        /// <summary>Gets or sets the Price.</summary>
        // using auto property here
        [RangeAttribute(0, Double.MaxValue, ErrorMessage = "Price must be >= 0")]
        public decimal Price
        {
            //get { return _price; }
            //set { _price = value; }
            get; set;
        } = 0;

        /// <summary>Gets or sets true or false if product is discontinued.</summary>
        public bool IsDiscontinued
        {    //Accessors
             get;set;
        }

        //public int ShowingOffAccessibility
        //{
        //    get { }
        //    internal set { }
        //}
        /// <summary>Gets the price, with any discontinued discounts.</summary>
        public decimal ActualPrice => IsDiscontinued ? (Price - (Price * DiscountPercentage)) : Price;
        //{
            
            //set { }
        //}

        ///// <summary> Get the product name. </summary>
        ///// <returns>The name.</returns>
        //public string GetName()
        //{
        //    return _name ?? ""; //null coalescing operator
        //}

        ///// <summary> Sets the product name. </summary>
        ///// <param name="value">The name.</param>
        //public void SetName( string value)
        //{
        //    _name = value ?? ""; //null coalescing operator
        //}

        /// <summary>Validates the product.</summary>
        /// <returns>Error message, if any</returns>

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();
            //if (Price < 0)
            //    errors.Add(new ValidationResult("Price must be >= 0", new[] { nameof(Price) }));

            return errors;
        }

        private string _name;
        private string _description;
        //private decimal _price;
        //private bool _isDiscontinued;
    }
}
