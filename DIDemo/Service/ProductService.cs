using DIDemo.Models;
using DIDemo.Repository;

namespace DIDemo.Service
{
    public class ProductService : IProductService
    {
        // add constructor & update the dependency
        private readonly IProductRepository repo;
        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }
        public int AddProduct(Product prod)
        {
            return repo.AddProduct(prod);
        }

        public int DeleteProduct(int id)
        {
           return repo.DeleteProduct(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return repo.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public int UpdateProduct(Product prod)
        {
            return repo.UpdateProduct(prod);
        }
    }
}
