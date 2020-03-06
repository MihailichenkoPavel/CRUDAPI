using CRUDAPI.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace CRUDAPI.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private IProductRepository productRepository;

        public ProductsController()
        {
            productRepository = new ProductRepository(new ProductContext());
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Product> All()
        {
            return productRepository.GetAll();
        }

        [HttpGet]
        [Route("get/{id}")]
        public Product Get(int id)
        {
            Product item = productRepository.GetById(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [HttpPost]
        [Route("create")]
        public Product Create(Product item)
        {
            item = productRepository.Add(item);
            return item;
        }

        [HttpPut]
        [Route("update")]
        public void Update(Product product)
        {
            productRepository.Update(product);
        }

        [HttpDelete]
        [Route("delete")]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}
