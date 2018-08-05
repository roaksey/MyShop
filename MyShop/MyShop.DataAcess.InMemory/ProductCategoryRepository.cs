using MyShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAcess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();

            }

        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;

        }
        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory pc)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == pc.Id);
            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = pc;
            }
            else
            {
                throw new Exception("Product Not Found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productToFind = productCategories.Find(p => p.Id == Id);

            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception("product not found");
            }

        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productToDelete = productCategories.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                productCategories.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product doesnot exist");
            }
        }

    }
}
