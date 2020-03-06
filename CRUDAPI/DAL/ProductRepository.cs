using System;
using System.Collections.Generic;

namespace CRUDAPI.Models
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }

        public Product Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            context.Products.Add(item);
            context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var item = context.Products.Find(id);
            if (item == null)
                throw new ArgumentNullException("item");
            context.Products.Remove(item);
            context.SaveChanges();
        }

        public void Update(Product item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            var objItem = context.Products.Find(item.Id);
            if (objItem != null)
            {
                objItem.Name = item.Name;
                objItem.Category = item.Category;
                objItem.Price = item.Price;
            }
            context.SaveChanges();
        }
    }
}