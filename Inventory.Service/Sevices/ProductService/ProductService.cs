using Task.Repositories;
using Inventory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.Service.Sevices.ProductService
{

    public class TransactionService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepository;

        public TransactionService(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void Insert(Product product)
        {
            _productRepository.Add(product);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}