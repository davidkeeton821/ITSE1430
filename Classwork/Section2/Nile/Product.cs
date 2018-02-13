using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Provides information about a product. </summary>
    public class Product
    {
        internal decimal DiscountPercentage = 0.10M;

        /// <summary>Gets or sets the description.</summary>
        /// <value></value>
        // value tag allows documenting default value if not "0"
        public string Description
        {
            //Accessors
            get { return _description ?? ""; }
            // Set method can do whatever needed, switch, if/else, method call etc.
            set { _description = value ?? ""; }
        }

        /// <summary>Gets or sets the name.</summary>
        public string Name
        {
            //Accessors
            get { return _name ?? ""; }
            set { _name = value; }
        }

        /// <summary>Gets or sets the Price.</summary>
        // using auto property here
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
        public decimal ActualPrice
        {
            get {
                if (IsDiscontinued)
                    return Price - (Price * DiscountPercentage);

                return Price;
            }
            //set { }
        }

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
        public string Validate ()
        {
            //NAme is requried
            if (String.IsNullOrEmpty(_name))
                return "Name cannot be empty";

            if (Price < 0)
                return "Price must be >= 0";

            return "";
        }

        private string _name;
        private string _description;
        //private decimal _price;
        //private bool _isDiscontinued;
    }
}
