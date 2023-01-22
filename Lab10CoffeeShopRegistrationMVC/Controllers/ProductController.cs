using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab10CoffeeShopRegistrationMVC.DataAccessLayer;
using Lab10CoffeeShopRegistrationMVC.Models;

namespace Lab10CoffeeShopRegistrationMVC.Controllers
{
    public class ProductController : Controller
    {
        private CoffeeShopContext db = new CoffeeShopContext();

        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new BadHttpRequestException("No Id Provided");
            }
            ProductViewModel product = db.Products
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (product == null)
            {
                throw new BadHttpRequestException("Id not found");
            }

            return View(product);
        }
    }
}
