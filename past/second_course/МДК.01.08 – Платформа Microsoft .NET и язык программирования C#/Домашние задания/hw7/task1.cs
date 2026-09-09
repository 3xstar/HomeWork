namespace hw7
{
    internal class task1
    {
        static void Main1(string[] args)
        {
            Person[] PERSONS =
            {
            new Person("John", 58, "New-York"),
            new Person("Maria", 19, "Moscow"),
            new Person("Kevin", 24, "London"),
            new Person("Gwen", 35, "Paris"),
            new Person("Tony", 26, "San-Francisco"),
            new Person("Tomas", 16, "Los-Angeles"),
            new Person("Sasha", 32, "Moscow"),
            new Person("Alex", 14, "Rome")
            };

            linq_manager l_m = new linq_manager();

            l_m.get_names(PERSONS);
            Console.WriteLine("\n");
            l_m.live_in_moscow(PERSONS);
            Console.WriteLine("\n");
            l_m.older_than_25(PERSONS);
            Console.WriteLine("\n");
            l_m.younget_than_25(PERSONS);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public Person(string name , int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }
    }

    class linq_manager
    {
        public void get_names(Person[] list)
        {
            var names = list.Select(p => p.Name);
            Console.WriteLine("All names:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public void live_in_moscow(Person[] list)
        {
            var moscow_persons = list.Where(p => p.City is "Moscow");
            Console.WriteLine("All person who live in Moscow:");
            foreach (var p in moscow_persons)
            {
                Console.WriteLine(p.Name);
            }
        }

        public void older_than_25(Person[] list)
        {
            var older_persons = list.Where(p => p.Age > 25);
            Console.WriteLine("All person who older than 25:");
            foreach (var p in older_persons)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }

        public void younget_than_25(Person[] list)
        {
            var younger_persons = list.Where(p => p.Age < 25).OrderBy(p => p.Age);
            Console.WriteLine("All person who younger than 25 (ordered by ascending):");
            foreach (var p in younger_persons)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }

    }
}
