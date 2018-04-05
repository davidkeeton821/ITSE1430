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

        public Product Add( Product product)
        {
            // if (product == null)
            //   throw new ArgumentNullException(nameof(product));

            product = product ?? throw new ArgumentNullException(nameof(product));

            //Validate product
            product.Validate();
            //var errors = product.TryValidate();
            //if (errors.Count() > 0)
            //{
            //    var error = Enumerable.First(errors);
            //    message = errors.ElementAt(0).ErrorMessage;
            //    return null;
            //};
            //var error = errors.FirstOrDefault();
            //if(error != null)
            //{
            //    message = error.ErrorMessage;
            //    return null;
            //}

            //Verify Unique product
            var existing = GetProductByNameCore(product.Name);
            if (existing != null)
                throw new Exception("Product Already Exists");
            //{
            //    message = "Product already exists.";
            //    return null;
            //};

            return AddCore(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return GetAllCore()
                .OrderBy(p => p.Name)
                .ThenByDescending(p => p.Id)
                .Select(p => p);

            //return from p in GetAllCore()
            //       orderby p.Name, p.Id descending
            //       select p;
        }
        public void Remove( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0");
            RemoveCore(id);
        }

        public Product Update( Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));


            //Validate product
            product.Validate();

            //Verify Unique product
            var existing = GetProductByNameCore(product.Name);
            if (existing != null && existing.Id != product.Id)
                throw new Exception("Product already exists");


            //Find Existing
            existing = existing ?? GetCore(product.Id);
            if (existing == null)
                throw new ArgumentException("Product not found", nameof(product));

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