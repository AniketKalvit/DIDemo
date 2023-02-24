using DIDemo.Models;
using DIDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DIDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;
        public ProductController(IProductService service)
        {
            this.service = service;
        }
        public ActionResult Index()
        {
            return View(service.GetAllProducts());
        }
        public ActionResult Details(int id)
        {
            var product = service.GetProductById(id);
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod) 
        {
            try
            {
                int result = service.AddProduct(prod);
                if(result==1)
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var product = service.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            try
            {
                int result = service.UpdateProduct(prod);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var product = service.GetProductById(id);
            return View(product);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]  
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteProduct(id);
                if (result == 1)
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
