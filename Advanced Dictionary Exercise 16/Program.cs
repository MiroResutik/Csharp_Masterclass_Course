namespace Advanced_Dictionary_Exercise_Section_6
{
    class Student
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Grade { get; set; }

        public Student(int id, string name, int grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Student> students = new Dictionary<int, Student>();

            // Add students
            students.Add(1, new Student(1, "John", 85));
            students.Add(2, new Student(2, "Alice", 90));
            students.Add(3, new Student(3, "Bob", 78));

            // Iterate the dictionary and print each student details
            foreach (var item in students)
            {
                Console.WriteLine(
                    $"Name: {item.Value.Name}, Id: {item.Value.Id}, Grade: {item.Value.Grade}"
                );
            }
        }
    }
}
