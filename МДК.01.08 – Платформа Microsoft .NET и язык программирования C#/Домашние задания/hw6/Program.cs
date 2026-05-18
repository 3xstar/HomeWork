namespace hw6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student_Manager student_manager = new Student_Manager();
            
            Student[] STUDENTS =
            {
                // Students younger than 26
                new Student("John Smith", 19, 85),
                new Student("Emily Johnson", 20, 92),
                new Student("Michael Brown", 18, 78),
                new Student("Sophia Davis", 21, 88),
                new Student("James Wilson", 19, 91),
                new Student("Olivia Martinez", 20, 76),
                new Student("William Anderson", 18, 95),
                new Student("Isabella Taylor", 22, 84),
                new Student("Benjamin Thomas", 19, 79),
                new Student("Mia Jackson", 20, 90),
                
                // Students older than 26
                new Student("Daniel White", 27, 88),
                new Student("Charlotte Harris", 28, 94),
                new Student("Matthew Martin", 30, 82),
                new Student("Amelia Thompson", 29, 91),
                new Student("David Garcia", 31, 87),
                new Student("Ella Robinson", 27, 93),
                new Student("Joseph Clark", 32, 79),
                new Student("Ava Rodriguez", 28, 96),
                new Student("Christopher Lewis", 29, 85),
                new Student("Grace Walker", 30, 90)
            };

            student_manager.excellent_students(STUDENTS);
            Console.WriteLine("\n");
            student_manager.students_names(STUDENTS);
            Console.WriteLine("\n");
            student_manager.sort_by_age(STUDENTS);
            Console.WriteLine("\n");
            student_manager.excellent_young_students(STUDENTS);
        }
    }

    class Student
    {
        public string name;
        public int age;
        public int middle_grade;

        public Student(string name, int age, int middle_grade)
        {
            this.name = name;
            this.age = age;
            this.middle_grade = middle_grade;
        }
    }

    class Student_Manager
    {
        public void excellent_students(Student[] students)
        {
            Console.WriteLine("Excellent students (middle grade 75 or higher):");
            var excellent_students = students.Where(s => s.middle_grade >= 75);
            foreach(Student student in excellent_students)
            {
                Console.WriteLine($"{student.name} - {student.middle_grade}");
            }
        }

        public void students_names(Student[] students)
        {
            var names = students.Select(s => s.name);
            Console.WriteLine("Names of all students:");
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }
        }

        public void sort_by_age(Student[] students)
        {
            var sorted_students = students.OrderBy(s => s.age);
            Console.WriteLine("Students ordered by age (lower to higher):");
            foreach(Student s in sorted_students)
            {
                Console.WriteLine($"{s.name} - {s.age}");
            }
        }

        public void excellent_young_students(Student[] students)
        {
            var excellent_young_students = students.Where(s => s.age < 25 && s.middle_grade >= 75).OrderBy(s => s.middle_grade);
            Console.WriteLine("Excellent young students ordered by middle grade (lower to higher):");
            foreach(Student s in excellent_young_students)
            {
                Console.WriteLine($"{s.name} - {s.middle_grade}");
            }
        }
    }
}
