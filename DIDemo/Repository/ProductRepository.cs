using DIDemo.Data;
using DIDemo.Models;

namespace DIDemo.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)// DI 
        {
            this.db = db;
        }
        public int AddProduct(Product prod)
        {
           int result = 0;
            db.Products.Add(prod);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;

            var prod = db.Products.Where(x => x.Id == id).FirstOrDefault();
            if (prod != null)
            {
                db.Products.Remove(prod);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            var prod = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return prod;
        }

        public int UpdateProduct(Product prod)
        {
            int result = 0;

            var p = db.Products.Where(x => x.Id == prod.Id).FirstOrDefault();
            if (p != null)
            {
                p.Name = prod.Name;
                p.Company = prod.Company;
                p.Price = prod.Price;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
