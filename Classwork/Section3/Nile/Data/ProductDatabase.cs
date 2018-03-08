using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data
{
    /// <summary>Provides an in-memory product database/// </summary>
    public abstract class ProductDatabase : IProductDatabase
    {

        public Product Add( Product product, out string message )
        {
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product
            var errors = ObjectValidator.Validate(product);
            if (errors.Count() > 0)
            {
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            };

            //Verify Unique product
            var existing = GetProductByName(product.Name);
            if(existing != null)
            {
                message = "Product already exists.";
                return null;
            };
            //var index = FindEmptyProductIndex();
            //if (index < 0)
            //{
            //    message = "Out of memory";
            //    return null;
            //};
            //Clone the object
            product.Id = _nextId++;
            _products.Add(Clone(product));
            message = null;

            //return a copy
            return product;
        }

        public Product Update( Product product, out string message )
        {
            if (product == null)
            {
                message = "Product cannot be null.";
                return null;
            };

            //Validate product
            var errors = ObjectValidator.Validate(product);
            if (errors.Count() > 0)
            {
                message = errors.ElementAt(0).ErrorMessage;
                return null;
            };

            //Verify Unique product
            var existing = GetProductByName(product.Name);
            if (existing != null && existing.Id != product.Id)
            {
                message = "Product already exists.";
                return null;
            };

            //Find Existing
            existing = existing ?? GetByID(product.Id);
            if (existing == null)
            {
                message = "Product not found";
                return null;
            }
            //Clone the object
            //_products[existingIndex] = Clone(product);
            //

            message = null;
            return AddCore();
        }

        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract Product AddCore( Product product );
        protected abstract Product GetCore( int id );

        public void Remove( int id )
        {
            if (id > 0)
            {
                var existing = GetByID(id);
                if (existing != null)
                    _products.Remove(existing);
            };
        }

        //public IEnumerable<Product> GetAll()
        //{
        //    //return a copy so caller cannot change the underlying data
        //    var items = new List<Product>();
        //    foreach (var product in _products)
        //    {
        //        if (product != null)
        //            items.Add(Clone(product));
        //    };

        //    return items;
        //}

        protected override IEnumerable<Product> GetAllCore()
        {
            foreach (var product in _products)
            {
                if (product != null)
                    yield return Clone(product);
            };

        }

        private Product GetProductByName( string name )
        {
            foreach (var product in _products)
            {
                //case insensitive comparison
                if (String.Compare(product.Name, name, true) == 0)
                    return product;
            };

            return null;
        }

        private Product Clone( Product item )
        {
            var newProduct = new Product();
            Copy(newProduct, item);

            return newProduct;
        }

        private void Copy( Product target, Product source )
        {
            var newProduct = new Product();
            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.IsDiscontinued = source.IsDiscontinued;
        }

        //private int FindEmptyProductIndex()
        //{
        //    //find empty arrary element
        //    for (var index = 0; index < _products.Length; index++)
        //    {
        //        if (_products[index] == null)
        //            return index;
        //    };

        //    return -1;
        //}

        private Product GetByID( int id )
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                    return product;
            };

            return null;
        }

        private readonly List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}