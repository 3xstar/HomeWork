namespace hw2
{
    internal class task4
    {
        static void Main(string[] args)
        {
            int end_point = 10;
            int[] nums = new int[end_point];
            int new_numb = 1;

            Console.WriteLine("Массив обычных чисел: ");
            for(int i = 0; i < end_point; i++)
            {
                nums[i] = new_numb;
                new_numb++;
            }

            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }


            int[] nums2 = new int[end_point];
            Console.WriteLine("Массив квадратов первого массива: ");
            for (int i = 0; i < nums2.Length; i++)
            {
                nums2[i] = nums[i] * nums[i];
            }

            foreach (int i in nums2)
            {
                Console.WriteLine(i);
            }


            int[] nums3 = new int[end_point];
            Console.WriteLine("Массив кубов первого массива чисел: ");
            for (int i = 0; i < nums3.Length; i++)
            {
                nums3[i] = nums[i] * nums[i] * nums[i];
            }

            foreach (int i in nums3)
            {
                Console.WriteLine(i);
            }

        }
    }
}
