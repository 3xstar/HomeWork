using System;
using System.Linq;


namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] users = new string[20];

            while (true)
            {
                Console.WriteLine("1. добавить пользоователя\n" +
                    "2. удалить пользователя\n" +
                    "3. изменить пользоватея\n" +
                    "4. показать пользователей");

                Console.Write("введите номер действия: ");
                int action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        users = AddUser(users);
                        break;
                    case 2:
                        users = RemoveUser(users);
                        break;
                    case 3:
                        ChangeUser(users);
                        break;
                    case 4:
                        ShowUsers(users);
                        break;
                    default:
                        Console.WriteLine("неверная команда!");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
        
        static string[] AddUser(string[] users)
        {
            Console.WriteLine("добавление пользователя");
            Console.Write("введите имя нового пользователя: ");
            string newUser = Console.ReadLine();

            for (int i = 0; i < users.Length; i++)
            {
                if (string.IsNullOrEmpty(users[i]))
                {
                    users[i] = newUser;
                    break;
                }
            }
            Console.WriteLine("пользователь добавлен");
            return users;
        }

        static string[] ChangeUser(string[] users)
        {
            Console.WriteLine("изменение пользователя");

            Console.WriteLine("список пользователей:");
            ShowUsers(users);

            Console.Write("Введите имя изменяемого пользователя: ");
            string changeUser = Console.ReadLine();

            if (users.Contains(changeUser))
            {
                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i] == changeUser)
                    {
                        Console.WriteLine("введите новое имя пользователя: ");
                        string newName = Console.ReadLine();
                        users[i] = newName;
                        Console.WriteLine("пользователь изменен");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("пользователя нет!");
            }

            return users;
        }

        static string[] RemoveUser(string[] users)
        {
            Console.WriteLine("удаление пользователя");

            Console.WriteLine("список пользователей:");
            ShowUsers(users);

            Console.Write("Введите имя удаляемого пользователя: ");
            string removeUser = Console.ReadLine();

            if (users.Contains(removeUser))
            {
                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i] == removeUser)
                    {
                        users[i] = string.Empty;
                        Console.WriteLine("пользователь удален");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("пользователя нет!");
            }

            return users;
        }

        static void ShowUsers(string[] users)
        {
            Console.WriteLine("отображение пользователей");

            int count = 0;
            foreach (string user in users)
            {
                count++;
                Console.WriteLine($"{count}. {user}");
            }
        }
    }
}
