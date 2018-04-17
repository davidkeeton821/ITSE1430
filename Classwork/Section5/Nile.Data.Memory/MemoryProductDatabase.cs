using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Data.Memory
{
    /// <summary>Provides an in-memory product database/// </summary>
    public class MemoryProductDatabase : ProductDatabase
    {
        public MemoryProductDatabase()
        {
            //Array version
            //var prods = new []
            //    {
            //        new Product(),
            //        new Product()
            //    };

            //_products = new List<Product>()
            //{
            //    //Seed products
            //    new Product() {Id = _nextId++,Name = "iPhone X",
            //                   IsDiscontinued = true, Price = 1500,},
            //    new Product() {Id = _nextId++,Name = "Windows Phone",
            //                   IsDiscontinued = true,Price = 15,},
            //    new Product() {Id = _nextId++,Name = "Samsung S8",
            //                   IsDiscontinued = false,Price = 800}
            //};
        }


        protected override Product AddCore( Product product)
        {
            //Clone the object
            product.Id = _nextId++;
            _products.Add(Clone(product));

            //return a copy
            return product;
        }
 
        protected override Product GetCore( int id )
        {
            return (from p in _products
                   where p.Id == id
                   select p).FirstOrDefault();

            //var items = from p in _products
            //            where p.Id == id
            //            select p;

            //return items.FirstOrDefault();
             
            //return _products.FirstOrDefault(p => p.Id == id);
            //foreach (var product in _products)
            //{
            //    if (product.Id == id)
            //        return product;
            //};

            //return null;
        }
        protected override IEnumerable<Product> GetAllCore()
        {
            return from p in _products
                   select Clone(p);

            //foreach (var product in _products)
            //{
            //    if (product != null)
            //        yield return Clone(product);
            //};

            //return _products.Select(p => Clone(p));
        }
        protected override void RemoveCore( int id )
        {      
                var existing = GetCore(id);
                if (existing != null)
                    _products.Remove(existing);
        }

        protected override Product UpdateCore( Product product)
        {
            var existing = GetCore(product.Id);

            //Clone the object
            //_products[existingIndex] = Clone(product);
            Copy(existing, product);

            //return a copy
            return product;
        }

        protected override Product GetProductByNameCore( string name )
        {
            return (from p in _products
                    where String.Compare(p.Name, name, true) == 0
                    select p).FirstOrDefault();

            //foreach (var product in _products)
            //{
            //    //case insensitive comparison
            //    if (String.Compare(product.Name, name, true) == 0)
            //        return product;
            //};
            //return null;

                   //return _products.FirstOrDefault(p => String.Compare(p.Name, name, true) == 0);

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

        private readonly List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}