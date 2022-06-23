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
        private ProductsContext _productsContext = new ProductsContext();

        public Product Get(int id)
        {
            if (_productsContext.Products.Find(id) != null)
            {
                _productsContext.Entry(findedProduct).Reference(x => x.productsContext).Load();
            }
            return _productsContext.Products.Find(id);
        }

        public List<Product> GetAll()
        {
            return _productsContext.Products.Include("ProductType").ToList();
        }

        public void Create(Product product)
        {
            Product findedProduct = _productsContext.Products.Add(product);
            _productsContext.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            Product findedProduct = _productsContext.Products.Find(id);
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
            _productsContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Product findedProduct = _productsContext.Products.Find(id);
            _productsContext.Products.Remove(findedProduct);
            _productsContext.SaveChanges();
        }

        internal static List<ProductsContext> GetAllProductContext()
        {
            throw new NotImplementedException();
        }
    }
}
