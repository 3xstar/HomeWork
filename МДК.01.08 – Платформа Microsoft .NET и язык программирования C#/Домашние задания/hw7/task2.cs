using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace hw7
{
    internal class task2
    {
        static void Main(String[] args)
        {
            Product[] PRODUCTS = 
            {
                new Product("Potato", 100, "Vegetables", 3),
                new Product("Cucumber", 120, "Vegetables", 4),
                new Product("Milk", 80, "Dairy products", 5),
                new Product("Kefir", 90, "Dairy products", 3),
                new Product("Bread", 50, "Bakery products", 4),
                new Product("Bun", 30, "Bakery products", 5),
                new Product("Champagne", 2000, "Alcohol", 4),
                new Product("Bear", 200, "Alcohol", 3),
                new Product("Steak", 1500, "Meat", 4),
                new Product("Minced meat", 300, "Meat", 5),
                new Product("Fish", 500, "Seafood", 3),
                new Product("Squid", 3000, "Seafood", 5)
            };

            linq_manager2 l_q = new linq_manager2();

            l_q.price_less_1000(PRODUCTS);
            Console.WriteLine("\n");
            l_q.rating_is_5(PRODUCTS);
            Console.WriteLine("\n");
            l_q.sort_by_category(PRODUCTS);
        }
    }


    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Rating { get; set; }

        public Product(string name, decimal price, string category, int rating)
        {
            Name = name;
            Price = price;
            Category = category;
            Rating = rating;
        }
    }

    class linq_manager2
    {
        public void price_less_1000(Product[] list)
        {
            var products_with_price = list.Where(p => p.Price < 1000);
            Console.WriteLine("Products with price less than 1000:");
            foreach (Product p in products_with_price)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
        }

        public void rating_is_5(Product[] list)
        {
            var products_with_rating = list.Where(p => p.Rating is 5);
            Console.WriteLine("Products with rating 5:");
            foreach (Product p in products_with_rating)
            {
                Console.WriteLine(p.Name);
            }
        }

        public void sort_by_category(Product[] list)
        {
            var vegetables = list.Where(p => p.Category is "Vegetables");
            var dairy_products = list.Where(p => p.Category is "Dairy products");
            var bakery_products = list.Where(p => p.Category is "Bakery products");
            var alcohol = list.Where(p => p.Category is "Alcohol");
            var meat = list.Where(p => p.Category is "Meat");
            var seafood = list.Where(p => p.Category is "Seafood");
            Console.WriteLine("SORTED PRODUCTS BY CATEGORY:");

            Console.WriteLine("Vegetables:");
            foreach (Product p in vegetables)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Dairy products:");
            foreach (Product p in dairy_products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Bakery products:");
            foreach (Product p in bakery_products)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Alcohol:");
            foreach (Product p in alcohol)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Meat:");
            foreach (Product p in meat)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
            Console.WriteLine("\n");
            Console.WriteLine("Seafood:");
            foreach (Product p in seafood)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }
        }
    }
}
