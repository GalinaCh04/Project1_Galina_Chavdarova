using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad2_project.Data;

namespace zad2_project.Business
{
    public class ProductsLogic
    {
        private ProductsContext productsContext = new ProductsContext();

        public Product Get(int id)
        {
            ProductsLogic findedProduct = productsContext.Product.Find(id);
            if (findedProduct != null)
            {
                productsContext.Entry(findedProduct).Reference(x => x.Type).Load();
            }
            return findedProduct;
        }

        public List<Product> GetAll()
        {
            return productsContext.Products.Include("ProductType").ToList();
        }

        public void Create(Product product)
        {
            Product findedProduct = productsContext.Products.Add(product);
            productsContext.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            Product findedProduct = productsContext.Products.Find(id);
            if (findedProduct == null)
            {
                return;
            }
            findedProduct.name_na_product = product.name_na_product;
            findedProduct.opisanie = product.opisanie;
            findedProduct.Price = product.Price;
            findedProduct.size = product.size;
            findedProduct.vid_na_product = product.vid_na_product;
            findedProduct.type = product.type;
            productsContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Product findedProduct = productsContext.Products.Find(id);
            productsContext.Products.Remove(findedProduct);
            productsContext.SaveChanges();
        }
    }
}
