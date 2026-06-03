using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjectsAndQueryOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of UniversityManager to manage universities and students
            UniversityManager un = new UniversityManager();

            un.MaleStudents();
            un.FemaleStudents();
            un.SortStudentsByAge();
            
            un.StudentAndUniversityNameCollection();
            un.AllStudentsFromUniversity();
            Console.ReadKey();
        }
    }
    // Class representing a university with properties and a method to print details
    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int EstablishedYear { get; set; }

        public void PrintDetails()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Location: {Location}, Established Year: {EstablishedYear}");
        }
    }
    // Class representing a student with properties and a method to print details
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        // Foreign key to University
        public int UniversityId { get; set; }
        public string Gender { get; set; }
        public void PrintDetails()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}, UniversityId: {UniversityId}");
        }
    }
    // Class to manage universities and students, providing methods to filter and display students
    class UniversityManager
    {
        // In-memory collection to store universities
        public List<University> universities;
        public List<Student> students;
        public UniversityManager()
        {
            // Initializing the collections
            universities = new List<University>();
            students = new List<Student>();

            // Adding some sample universities to the collection
            universities.Add( new University() { Id = 1, Name = "Harvard University", Location = "Cambridge, MA", EstablishedYear = 1636 });
            universities.Add(new University() { Id = 2, Name = "Stanford University", Location = "Stanford, CA", EstablishedYear = 1885 });
            universities.Add(new University() { Id = 3, Name = "Massachusetts Institute of Technology", Location = "Cambridge, MA", EstablishedYear = 1861 });
            universities.Add(new University() { Id = 4, Name = "University of California, Berkeley", Location = "Berkeley, CA", EstablishedYear = 1868 });
            universities.Add(new University() { Id = 5, Name = "University of Oxford", Location = "Oxford, England", EstablishedYear = 1096 });


            // Adding some sample students to the collection
            students.Add(new Student() { Id = 1, Name = "Alice", Gender = "Female", Age = 19, UniversityId = 1 });
            students.Add(new Student() { Id = 2, Name = "Bob", Gender = "Male", Age = 22, UniversityId = 2 });
            students.Add(new Student() { Id = 3, Name = "Charlie", Gender = "Male", Age = 21, UniversityId = 3 });
            students.Add(new Student() { Id = 4, Name = "David", Gender = "Male", Age = 23, UniversityId = 4 });
            students.Add(new Student() { Id = 5, Name = "Eve", Gender = "Female", Age = 24, UniversityId = 5 });
            students.Add(new Student() { Id = 6, Name = "Frank", Gender = "Male", Age = 22, UniversityId = 2 });
            students.Add(new Student() { Id = 7, Name = "Grace", Gender = "Male", Age = 27, UniversityId = 1 });
            students.Add(new Student() { Id = 8, Name = "Heidi", Gender = "Female", Age = 23, UniversityId = 3 });
            students.Add(new Student() { Id = 9, Name = "Ivan", Gender = "Male", Age = 20, UniversityId = 4 });
            students.Add(new Student() { Id = 10, Name = "Judy", Gender = "Female", Age = 28, UniversityId = 5 });
            students.Add(new Student() { Id = 11, Name = "Kevin", Gender = "Male", Age = 20, UniversityId = 1 });
            students.Add(new Student() { Id = 12, Name = "Laura", Gender = "Female", Age = 21, UniversityId = 2 });
            students.Add(new Student() { Id = 13, Name = "Michael", Gender = "Male", Age = 24, UniversityId = 3 });
            students.Add(new Student() { Id = 14, Name = "Nina", Gender = "Female", Age = 22, UniversityId = 4 });
            students.Add(new Student() { Id = 15, Name = "Oscar", Gender = "Male", Age = 25, UniversityId = 5 });
            students.Add(new Student() { Id = 16, Name = "Paula", Gender = "Female", Age = 19, UniversityId = 1 });
            students.Add(new Student() { Id = 17, Name = "Quentin", Gender = "Male", Age = 23, UniversityId = 2 });
            students.Add(new Student() { Id = 18, Name = "Rachel", Gender = "Female", Age = 26, UniversityId = 3 });
            students.Add(new Student() { Id = 19, Name = "Samuel", Gender = "Male", Age = 21, UniversityId = 4 });
            students.Add(new Student() { Id = 20, Name = "Tina", Gender = "Female", Age = 22, UniversityId = 5 });




        }
        // Method to display student names along with their corresponding university names using LINQ query syntax
        public void StudentAndUniversityNameCollection()
        {
            var studentUniversityNames = from student in students
                                         join university in universities on student.UniversityId equals university.Id
                                         orderby student.Name
                                         select new { StudentName = student.Name, UniversityName = university.Name };
            Console.WriteLine("\nStudent and University Names:");
            foreach (var item in studentUniversityNames)
            {
                Console.WriteLine($"Student: {item.StudentName},\t University: {item.UniversityName}");
            }
        }
        // Method to display all students from a selected university using LINQ query syntax
        public void AllStudentsFromUniversity()
        {
            while (true)
            {
                //Console.Clear();

                Console.WriteLine("\nAvailable Universities:");
                Console.WriteLine("-----------------------");

                foreach (University university in universities)
                {
                    Console.WriteLine($"{university.Id}. {university.Name}");
                }

                Console.Write("\nEnter University Id: ");

                if (!int.TryParse(Console.ReadLine(), out int universityId))
                {
                    Console.WriteLine("Invalid input. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                University selectedUniversity = universities
                    .FirstOrDefault(u => u.Id == universityId);

                if (selectedUniversity == null)
                {
                    Console.WriteLine("University not found. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                IEnumerable<Student> universityStudents =
                    from student in students
                    where student.UniversityId == universityId
                    select student;

                Console.WriteLine($"\nStudents from {selectedUniversity.Name}:");
                Console.WriteLine(new string('-', 40));

                if (!universityStudents.Any())
                {
                    Console.WriteLine("No students found.");
                }
                else
                {
                    foreach (Student student in universityStudents)
                    {
                        student.PrintDetails();
                    }
                }

                Console.WriteLine("\nWould you like to:");
                Console.WriteLine("1 - View another university");
                Console.WriteLine("2 - Quit");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine();

                if (choice == "2")
                {
                    Console.WriteLine("\nGoodbye!");
                    break;
                }
            }
        }
        // Method to sort students by age using LINQ query syntax
        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;

            Console.WriteLine("\nStudents sorted by Age: ");

            foreach (Student student in sortedStudents)
            {
                student.PrintDetails();
            }

        }
        // Method to find and display male students from the collection
        public void MaleStudents()
        {
            // Using LINQ query syntax to filter male students
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;
            Console.WriteLine("\nMale Students: ");

            foreach (Student student in maleStudents)
            {
                student.PrintDetails();
            }
        }
        // Method to find and display male students from the collection
        public void FemaleStudents()
        {
            // Using LINQ query syntax to filter male students
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "Female" select student;
            Console.WriteLine("\nFemale Students: ");

            foreach (Student student in femaleStudents)
            {
                student.PrintDetails();
            }
        }
        // Method to add a new university to the collection of universities 
        public void AddUniversity(University university)
        {
            universities.Add(university);
        }
        // Method to retrieve all universities from the collection 
        public IEnumerable<University> GetAllUniversities()
        {
            return universities;
        }
    }
}
