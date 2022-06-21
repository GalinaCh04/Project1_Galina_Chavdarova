using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad2_project.Data;

namespace zad2_project.Business
{
    public class ProductTypeLogic
    {
        private ProductsContext productsContext = new ProductsContext();
        public List<ProductType> GetTypes()
        {
            return productsContext.GetType.ToList();
        }

        public string GetTypeById(int id)
        {
            return productsContext.GetType.ToList();
        }

        public string GetTypeById(int id)
        {
            return productsContext.GetType.Find(id).name_na_product;
        }
    }
}
