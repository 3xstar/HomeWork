namespace hw2
{
    internal class task3
    {
        static void Main4(string[] args)
        {
            int[] numbers = {1, 2, 3, 4, 5};
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            int sum = 0;

            Console.Write("Сумма массива: ");

            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            Console.Write(sum);
        }
    }
}
