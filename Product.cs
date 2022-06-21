using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2_project.Data
{
   public class Product
    {
        public int Id { get; set; }  
        public string name_na_product { get; set; }
        public string opisanie { get; set; }
        public decimal Price { get; set; }
        public int size { get; set; }
        public int vid_na_product { get; set; }
        public int type { get; set; }

    }
}
