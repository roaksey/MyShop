using MyShop.Core.Model;
using MyShop.Core.ViewModel;
using MyShop.DataAcess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        InMemoryRepository<Product> context;
        InMemoryRepository<ProductCategory> productCategories;

        public ProductManagerController()
        {
            context = new InMemoryRepository<Product>();
            productCategories = new InMemoryRepository<ProductCategory>();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        
        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();

            viewModel.product = new Product();
            viewModel.productCategory = productCategories.Collection();

            return View(viewModel);
          
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            
            if(!ModelState.IsValid)
            {
                return View(product);

            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        
       public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if(product == null)
            {
                return HttpNotFound();

            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.product = product;
                viewModel.productCategory = productCategories.Collection();
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            Product product = context.Find(p.Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    product.Name = p.Name;
                    product.Image = p.Image;
                    product.Description = p.Description;
                    product.Price = p.Price;
                    product.Category = p.Category;

                    context.Commit();
                    return RedirectToAction("Index");
                    
                }
                return View(product);


            }
        }

        public ActionResult Delete(string Id)
        {
            Product product = context.Find(Id);
            if(product != null)
            {
                return View(product);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(Product product)
        {
            if(product != null)
            {
                context.Delete(product.Id);
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }




    }
}