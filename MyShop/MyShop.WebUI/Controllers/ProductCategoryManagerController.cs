using MyShop.Core.Model;
using MyShop.DataAcess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        InMemoryRepository<ProductCategory> context;

        public ProductCategoryManagerController()
        {
            context = new InMemoryRepository<ProductCategory>();
        }

        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategory = context.Collection().ToList();
            return View(productCategory);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if(productCategory != null)
            {
               
                return View(productCategory);

            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory,string Id)
        {
            ProductCategory productCategoryToEdit = context.Find(Id);
           if(productCategoryToEdit != null)
            {
                if (ModelState.IsValid)
                {
                    productCategoryToEdit.Category = productCategory.Category;
                                     
                }
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }

        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if(productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }

        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(ProductCategory productCategory)
        {
            context.Delete(productCategory.Id);
            return RedirectToAction("Index");

        }
    }
}