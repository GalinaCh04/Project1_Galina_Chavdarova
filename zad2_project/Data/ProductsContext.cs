using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2_project.Data
{
    public class ProductsContext: DbContext
    {
        public ProductsContext()
            :base("name_na_product=ProductsContext")
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
