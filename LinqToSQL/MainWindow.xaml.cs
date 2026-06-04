using LinqToSQL.MiroDBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declare the data context for LINQ to SQL
        LinqToSqlDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.MiroDBConnectionString"].ConnectionString;
                dataContext = new LinqToSqlDataClassesDataContext(connectionString);
                //InsertUniversity();
                //InsertStudent();
                //InsertLectures();
                //InsertStudentLectureAssociations();
                //GetUniversityOfToni();
                //GetLecturesFromToni();
                //GetAllStudentsFromYale();
                //GetAllStudentsFromYale();
                //GetAllLecturesFromBeijingTech();
                //GetAllUniversitiesWithMale();
                UpdateToni();
            }
            catch (Exception ex)
            {
                // Walk the full inner exception chain
                Exception current = ex;
                while (current != null)
                {
                    MessageBox.Show(current.Message);
                    current = current.InnerException;
                }
            }
        }
        // Method to insert a new university into the database
        public void InsertUniversity()
        {

            dataContext.ExecuteCommand("DELETE FROM University");

            // Create a new University object
            University yale = new University();
            yale.Name = "Yale";
            dataContext.Universities.InsertOnSubmit(yale);

            University beijingTech = new University();
            beijingTech.Name = "Beijing Tech";
            dataContext.Universities.InsertOnSubmit(beijingTech);


            // Insert the new university into the data context
            dataContext.Universities.InsertOnSubmit(yale);
            dataContext.Universities.InsertOnSubmit(beijingTech);
            //dataContext.Universities.InsertOnSubmit(mit);
            //dataContext.Universities.InsertOnSubmit(princeton);
            //dataContext.Universities.InsertOnSubmit(stanford);
            // Submit the changes to the database
            dataContext.SubmitChanges();

            // Refresh the data grid to show the new university
            MainDataGrid.ItemsSource = dataContext.Universities;
        }
        // Method to insert a new student into the database
        public void InsertStudent()
        {
            // Get the university object for each student to set the foreign key relationship 
            University yale = dataContext.Universities.First(un => un.Name.Equals("Yale"));
            University beijingTech = dataContext.Universities.First(un => un.Name.Equals("Beijing Tech"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "Carla", Gender = "female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Toni", Gender = "male", University = yale });
            students.Add(new Student { Name = "Leyle", Gender = "female", University = beijingTech });
            students.Add(new Student { Name = "Jame", Gender = "trans-gender", University = beijingTech });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;


        }
        // Method to insert new lectures into the database
        // DOES NOT WORK BECAUSE THE LECTURES TABLE HAS A NOT NULL CONSTRAINT ON THE NAME COLUMN, AND THERE ARE ALREADY LECTURES IN THE DATABASE WITH NAMES THAT ARE NOT UNIQUE.
        public void InsertLectures()
        {

        }
        // Method to insert associations between students and lectures into the database
        // DOES NOT WORK BECAUSE THE STUDENTLECTURE TABLE HAS A NOT NULL CONSTRAINT ON THE STUDENTID AND LECTUREID COLUMNS, AND THERE ARE ALREADY ASSOCIATIONS IN THE DATABASE WITH STUDENTIDS AND LECTUREIDS THAT ARE NOT UNIQUE.
        public void InsertStudentLectureAssociations()
        {

        }
        // Method to get the university of a student named Toni and display it in the data grid
        public void GetUniversityOfToni()
        {
            Student Toni = dataContext.Students.FirstOrDefault(st => st.Name.Equals("Toni"));

            University TonisUniversity = Toni.University;

            List<University> universities = new List<University>();
            universities.Add(TonisUniversity);

            MainDataGrid.ItemsSource = universities;

        }
        // Method to get the lectures that a student named Toni is enrolled in and display them in the data grid
        // DOES NOT WORK BECAUSE THE STUDENTLECTURE TABLE HAS A NOT NULL CONSTRAINT ON THE STUDENTID AND LECTUREID COLUMNS, AND THERE ARE ALREADY ASSOCIATIONS IN THE DATABASE WITH STUDENTIDS AND LECTUREIDS THAT ARE NOT UNIQUE.
        public void GetLecturesFromToni()
        {

        }
        // Method to get all students from the university named Yale and display them in the data grid
        public void GetAllStudentsFromYale()
        {
            var studentsFromYale = from student in dataContext.Students
                                   where student.University.Name == "Yale"
                                   select student;

            MainDataGrid.ItemsSource = studentsFromYale;
        }
        // Method to get all lectures that students from the university named Beijing Tech are enrolled in and display them in the data grid
        public void GetAllLecturesFromBeijingTech()
        {
            var lecturesFromBeijingTech = from sl in dataContext.StudentLectures
                                          join student in dataContext.Students on sl.StudentId equals student.Id
                                          where student.University.Name == "Beijing Tech"
                                          select sl.Lecture;

            MainDataGrid.ItemsSource = lecturesFromBeijingTech;
        }
        // Method to get all universities that have at least one male student and display them in the data grid
        public void GetAllUniversitiesWithMale()
        {
            var transgernderUniversities = from student in dataContext.Students
                                           join university in dataContext.Universities
                                           on student.University equals university
                                           where student.Gender == "Male"
                                           select university;

            MainDataGrid.ItemsSource = transgernderUniversities;
        }
        // Method to update the name of a student named Toni to Antonio and refresh the data grid to show the updated name

    }
}