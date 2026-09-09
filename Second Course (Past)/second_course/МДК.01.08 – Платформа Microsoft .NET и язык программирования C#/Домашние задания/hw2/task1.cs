namespace hw2
{
    internal class task1
    {
        static void Main2(string[] args)
        {
            string[] fruits = { "Apple", "Banana", "Grape", "Orange", "Pineapple" };
            foreach(string i in fruits)
            {
                Console.WriteLine(i);
            }

            Console.Write("Введите название фрукта для удаления: ");
            string user_fruit = Console.ReadLine();
            bool found = false;

            foreach (string i in fruits)
            {
                if (i == user_fruit)
                {
                    found = true;
                    List<string> fruits_list = new List<string>(fruits);
                    fruits_list.Remove(i);
                    fruits = fruits_list.ToArray();
                    Console.WriteLine("Обновленный массив без данного фрукта:");
                }
            }

            if(!found)
            {
                Console.WriteLine("Такого фрукта нет в массиве");
            }

            foreach (string i in fruits)
            {
                Console.WriteLine(i);
            }
        }
    }
}
