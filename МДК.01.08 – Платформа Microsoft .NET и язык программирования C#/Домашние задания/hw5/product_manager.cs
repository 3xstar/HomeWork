namespace tasks5
{
    internal class Program
    {
        static void ShowAllProducts(List<Dictionary<string, int>> products)
        {

            foreach (var product in products)
            {
                foreach (var item in product)
                {

                    Console.WriteLine($"Название товара: {item.Key} | Цена: {item.Value}");
                }
            }
        }

        static List<Dictionary<string, int>> AddProduct(List<Dictionary<string, int>> products)
        {
            Dictionary<string, int> product = new Dictionary<string, int>();
            Console.Write("Введите название товара: ");
            string title = Console.ReadLine();

            Console.Write("Введите цену товара: ");
            int price = Convert.ToInt32(Console.ReadLine());

            product.Add(title, price);
            products.Add(product);

            Console.WriteLine($"Был добавлен продукт - {title} с ценой: {price}");

            return products;
        }
        static List<Dictionary<string, int>> ChangeProduct(List<Dictionary<string, int>> products)
        {
            Console.Write("Введите название товара: ");
            string search_title = Console.ReadLine();

            foreach (var product in products)
            {
                if(product.ContainsKey(search_title))
                {
                    int oldVersion = product[search_title];

                    Console.Write("Введите новое название товара: ");
                    string title = Console.ReadLine();

                    Console.Write("Введите новую цену товара: ");
                    int price = Convert.ToInt32(Console.ReadLine());

                    product.Remove(search_title);
                    product.Add(title, price);

                    Console.WriteLine($"Изменение товара {search_title}...\nНовое название товара: {title}\nНовая цена товара: {price}");
                    return products;
                }
            }

            return products;
        }

        static List<Dictionary<string, int>> RemoveProduct(List<Dictionary<string, int>> products)
        {
            Console.Write("Введите название товара: ");
            string title = Console.ReadLine();

            for(int i = 0; i < products.Count(); i++)
            {
                if (products[i].ContainsKey(title))
                {
                    products.RemoveAt(i);
                    Console.WriteLine($"Продукт {title} был удален");
                }
            }
            return products;
        }

        static void getSum(List<Dictionary<string, int>> products)
        {
            Console.Write("Введите название товара: ");
            string title = Console.ReadLine();

            Console.Write("Введите количество товара: ");
            int count = Convert.ToInt32(Console.ReadLine());

            foreach (var product in products)
            {
                if (product.ContainsKey(title))
                {
                    foreach (var item in product)
                    {
                        int sum = item.Value * count;
                        Console.WriteLine($"Цена суммы товара {item.Key} в размере {count} штук равна: {sum}");
                    }
                }
            }
        }

            static void Main(string[] args)
            {
                List<Dictionary<string, int>> products = new List<Dictionary<string, int>>();
                Console.WriteLine("Для начала добавим 3 товара\n");
                AddProduct(products);
                AddProduct(products);
                AddProduct(products);

                while (true)
                {
                    Console.Write("(==== МЕНЕДЖЕР ТОВАРОВ ===)\n" +
                        "1. Посмотреть все товары\n" +
                        "2. Добавить товар\n" +
                        "3. Изменить товар\n" +
                        "4. Удалить товар\n" +
                        "5. Получить сумму за количество товара\n" +
                        "Введите номер действия: ");
                    string answer = Console.ReadLine();

                    switch (answer)
                    {
                        case "1":
                            ShowAllProducts(products);
                            break;
                        case "2":
                            AddProduct(products);
                            break;
                        case "3":
                            ChangeProduct(products);
                            break;
                        case "4":
                            RemoveProduct(products);
                            break;
                        case "5":
                            getSum(products);
                            break;

                        default:
                            Console.WriteLine("Неправильное значение");
                            break;

                }
            }
        }
    }
}
