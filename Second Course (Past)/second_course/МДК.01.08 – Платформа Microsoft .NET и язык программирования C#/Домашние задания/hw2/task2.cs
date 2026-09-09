namespace hw2
{
    internal class task2
    {
        static void Main3(string[] args)
        {
            string[] names = { "Zahar", "Vadim", "Sasha", "Nikita", "Grisha" };
            foreach (string i in names)
            {
                Console.WriteLine(i);
            }

            Console.Write("Введите название имени для поиска: ");
            string user_name = Console.ReadLine();
            bool found = false;

            foreach (string i in names)
            {
                if (i == user_name)
                {
                    found = true;
                    Console.WriteLine("Имя найдено :)");
                }
            }

            if (!found)
            {
                Console.WriteLine("Имя не найдено :(");
            }
        }
    }
}
