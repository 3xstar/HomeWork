namespace homework
{
    internal class Program
    {
        static void DrawField(List<List<char>> field)
        {
            Console.Clear();
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (field[i][j] == '#')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (field[i][j] == '*')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (field[i][j] == ' ')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else if (field[i][j] == 'x')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }

        static List<List<char>> CreateField()
        {
            List<List<char>> field = new List<List<char>>();

            for (int i = 0; i < 25; i++)
            {
                field.Add(new List<char>());
                for (int j = 0; j < 25; j++)
                {
                    if (i == 0 || i == 24)
                    {
                        field[i].Add('#');
                    }
                    else if (j == 0 || j == 24)
                    {
                        field[i].Add('#');
                    }
                    else
                    {
                        field[i].Add(' ');
                    }
                }
            }
            return field;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====SNAKE THE GAME=====");

            List<List<char>> filed = CreateField();

            Random random = new Random();
            int foodX = random.Next(2, 25);
            int foodY = random.Next(2, 25);

            List<(int x, int y)> snake = new List<(int x, int y)>();
            snake.Add((12, 12));
            snake.Add((12, 11));

            while (true)
            {
                foreach (var segment in snake)
                {
                    filed[segment.x][segment.y] = 'x';
                }
                filed[foodX][foodY] = '*';
                DrawField(filed);

                Console.Write("w - вперед, s - вниз, d - вправо, a - назад");
                char direction = Console.ReadKey().KeyChar;
                direction = char.ToLower(direction);

                foreach (var segment in snake)
                {
                    filed[segment.x][segment.y] = ' ';
                }

                var currentHead = snake[0];
                (int x, int y) newHead = currentHead;

                if (direction == 'w')
                {
                    newHead.x--;
                }
                else if (direction == 's')
                {
                    newHead.x++;
                }
                else if (direction == 'd')
                {
                    newHead.y++;
                }
                else if (direction == 'a')
                {
                    newHead.y--;
                }

                if (filed[newHead.y][newHead.x] == '#')
                {
                    Console.Clear();
                    Console.WriteLine("=====GAME OVER=====\nвы врезались в стену :(");
                    return;
                }

                snake.Insert(0, newHead);

                for (int i = 1; i < snake.Count(); i++)
                {
                    if (newHead.x == snake[i].x && newHead.y == snake[i].y)
                    {
                        Console.Clear();
                        Console.WriteLine("=====GAME OVER=====\nвы съели себя :(");
                        return;
                    }
                }

                if (newHead.x == foodX && newHead.y == foodY)
                {
                    foodX = random.Next(2, 19);
                    foodY = random.Next(2, 19);
                }
                else
                {
                    snake.RemoveAt(snake.Count - 1);
                }
            }
        }
    }
}