using System.Collections.Generic;

namespace CRUDAPI.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Add(Product item);
        void Delete(int id);
        void Update(Product item);
    }
}