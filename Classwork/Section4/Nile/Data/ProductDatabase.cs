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
            var errors = product.Validate();
            //if (errors.Count() > 0)
            //{
            //    var error = Enumerable.First(errors);
            //    message = errors.ElementAt(0).ErrorMessage;
            //    return null;
            //};
            var error = errors.FirstOrDefault();
            if(error != null)
            {
                message = error.ErrorMessage;
                return null;
            }

            //Verify Unique product
            var existing = GetProductByNameCore(product.Name);
            if(existing != null)
            {
                message = "Product already exists.";
                return null;
            };

            message = null;
            return AddCore(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return GetAllCore();
        }
        public void Remove( int id )
        {
            if (id > 0)
            {
                RemoveCore(id);
            };
        }

        public Product Update( Product product, out string message )
        {
            message = "";

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
            var existing = GetProductByNameCore(product.Name);
            if (existing != null && existing.Id != product.Id)
            {
                message = "Product already exists.";
                return null;
            };

            //Find Existing
            existing = existing ?? GetCore(product.Id);
            if (existing == null)
            {
                message = "Product not found";
                return null;
            }

            return UpdateCore(product);
        }

        protected abstract IEnumerable<Product> GetAllCore();
        protected abstract Product AddCore( Product product );
        protected abstract Product GetCore( int id );
        protected abstract Product UpdateCore( Product product );
        protected abstract void RemoveCore( int id );
        protected abstract Product GetProductByNameCore( string name );
    }
}