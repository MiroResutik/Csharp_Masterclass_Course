using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqWithXML
{
    internal class Program
    {

        static void Main(string[] args)
        {

            // XML string representing a list of students with their details
            string studentsXML =
            @"<Students>
                <Student>
                    <Name>Emily Chen</Name>
                    <Age>19</Age>
                    <University>Beijing Tech</University>
                    <Semester>2</Semester>
                    <Major>Engineering</Major>
                    <Email>emily.chen@example.com</Email>
                </Student>

                <Student>
                    <Name>Michael Johnson</Name>
                    <Age>20</Age>
                    <University>Harvard</University>
                    <Semester>3</Semester>
                    <Major>Mathematics</Major>
                    <Email>michael.johnson@example.com</Email>
                </Student>

                <Student>
                    <Name>Sarah Williams</Name>
                    <Age>21</Age>
                    <University>Stanford</University>
                    <Semester>4</Semester>
                    <Major>Physics</Major>
                    <Email>sarah.williams@example.com</Email>
                </Student>

                <Student>
                    <Name>David Brown</Name>
                    <Age>22</Age>
                    <University>MIT</University>
                    <Semester>5</Semester>
                    <Major>Business</Major>
                    <Email>david.brown@example.com</Email>
                </Student>

                <Student>
                    <Name>Olivia Taylor</Name>
                    <Age>23</Age>
                    <University>Oxford</University>
                    <Semester>6</Semester>
                    <Major>Biology</Major>
                    <Email>olivia.taylor@example.com</Email>
                </Student>

                <Student>
                    <Name>James Anderson</Name>
                    <Age>24</Age>
                    <University>Yale</University>
                    <Semester>7</Semester>
                    <Major>Computer Science</Major>
                    <Email>james.anderson@example.com</Email>
                </Student>

                <Student>
                    <Name>Sophia Martinez</Name>
                    <Age>25</Age>
                    <University>Beijing Tech</University>
                    <Semester>8</Semester>
                    <Major>Engineering</Major>
                    <Email>sophia.martinez@example.com</Email>
                </Student>

                <Student>
                    <Name>Daniel Wilson</Name>
                    <Age>26</Age>
                    <University>Harvard</University>
                    <Semester>9</Semester>
                    <Major>Mathematics</Major>
                    <Email>daniel.wilson@example.com</Email>
                </Student>

                <Student>
                    <Name>Emma Davis</Name>
                    <Age>27</Age>
                    <University>Stanford</University>
                    <Semester>10</Semester>
                    <Major>Physics</Major>
                    <Email>emma.davis@example.com</Email>
                </Student>

                <Student>
                    <Name>Benjamin Moore</Name>
                    <Age>18</Age>
                    <University>MIT</University>
                    <Semester>1</Semester>
                    <Major>Business</Major>
                    <Email>benjamin.moore@example.com</Email>
                </Student>
</Students>";

            // Parse the XML string into an XDocument object for LINQ queries
            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            //XDocument studentsXdoc = new XDocument();
            //XDocument studentsXdoc = XDocument.Load("Students.xml");

            // LINQ query to select students older than 20 and project their details into an anonymous type
            var students = from student in studentsXdoc.Descendants("Student") // Filter students based on age
                           where (int)student.Element("Age") > 20
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = (int)student.Element("Age"),
                               University = student.Element("University").Value,
                               Semester = (int)student.Element("Semester"),
                               Major = student.Element("Major").Value,
                               Email = student.Element("Email").Value
                           };

            Console.WriteLine("\nList of students:");
            // Iterate through the filtered list of students and print their details
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, University: {student.University}, Semester: {student.Semester}, Major: {student.Major}, Email: {student.Email}");


            }
            // LINQ query to sort the students by age in descending order
            var sortedSutendts = from student in students
                                 orderby student.Age  // Sort students by age in descending order
                                 select student;

            Console.WriteLine("\nList of students sorted by Age:");
            foreach (var student in sortedSutendts)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, University: {student.University}, Semester: {student.Semester}, Major: {student.Major}, Email: {student.Email}");


            }
            Console.ReadKey();
        }
    }
}
