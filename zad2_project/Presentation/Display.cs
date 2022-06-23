using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad2_project.Business;
using zad2_project.Data;

namespace zad2_project.Presentation
{
    class Display
    {
        private ProductsLogic productLogic = new ProductsLogic();
        private int closeOperation = 6;
        public Display()
        {
            Input();
        }

      
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperation);
        }

        private void PrintProduct(Product product)
        {
            Console.WriteLine($"{product.Id} {product.name_na_product} {product.type} ");
        }
 
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            ProductsLogic productsController = new ProductsLogic();
            Product product = productsController.Get(id);
            if (product != null)
            {
                PrintProduct(product);
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            ProductsLogic productsController = new ProductsLogic();
            Product product = productsController.Get(id);
            if (product != null)
            {
                productsController.Delete(id);
            }
        }

        private void Update()
        {
            Console.Write("Enter the Product's id: ");
            int productId = int.Parse(Console.ReadLine());
            Product newProduct = productLogic.Get(productId);
            if (newProduct==null)
            {
                Console.WriteLine("No searching product");
                return;
            }

            PrintProduct(newProduct);

            Console.WriteLine("Enter the new values: ");
            Console.Write("Name_na_product: ");
            newProduct.name_na_product = Console.ReadLine();

            Console.Write("Size:");
            newProduct.size = int.Parse(Console.ReadLine());

            ProductTypeLogic productTypeLogic = new ProductTypeLogic();
            List<ProductsContext> AllproductsContexts = ProductsLogic.GetAllProductContext();
            Console.WriteLine("type:");
            Console.WriteLine(new string ('-', 5));
            foreach (var item in AllproductsContexts)
            {
                Console.WriteLine(item.Products + ". " + item.Products);
            }
            Console.WriteLine("Izberi type:");
            newProduct.Id = int.Parse(Console.ReadLine());

            ProductsLogic productsController = new ProductsLogic();
            productsController.Update(productId, newProduct);
        }

        private void Add()
        {
            Product newProduct = new Product();
            Console.Write("Name_na_product: ");
            newProduct.name_na_product = Console.ReadLine();

            Console.Write("Size: ");
            newProduct.size = int.Parse(Console.ReadLine());

            ProductsLogic productsLogic = new ProductsLogic();
            List<Product> AllproductsContext = productsLogic.GetAll();
            Console.WriteLine("type:");
            Console.WriteLine(new string('-', 5));
            foreach (var item in AllproductsContext)
            {
                Console.WriteLine(item.Id + ". " + item.name_na_product);
            }

            Console.Write("Izberi type: ");
            newProduct.Id = int.Parse(Console.ReadLine());

            ProductsLogic productsController = new ProductsLogic();
            productsController.Create(newProduct);

            Console.WriteLine($"{newProduct.Id} {newProduct.name_na_product} {newProduct.opisanie} { newProduct.size} ");
           
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Products" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            ProductsLogic productsController = new ProductsLogic();
            var products = productsController.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} { item.name_na_product} {item.opisanie} { item.Price} { item.size} { item.vid_na_product} { item.type}");
            }
        }
       
    }

}
