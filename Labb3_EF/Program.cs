using Labb3_EF.Models;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace Labb3_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new Labb3DbContext();
            GetStudents(context);
            GetStudentsInClass(context);
            AddNewEmployee(context);
        }
        static void GetStudents(Labb3DbContext context)
        {
            var students= context.Students.ToList();
            Console.WriteLine("1. Sort by FirstName\n2. Sort by Lastname");
            int wichName = int.Parse(Console.ReadLine());
            Console.WriteLine("1. Ascending Order\n2. Decending Order");
            int order=int.Parse(Console.ReadLine());
            if (wichName == 1)
            {
                if(order == 1)
                {
                    students = students.OrderBy(x => x.Fname).ToList();
                }
                else
                {
                    students = students.OrderByDescending(x => x.Fname).ToList();
                }
            }
            if(wichName == 2)
            {
                if (order == 1)
                {
                    students = students.OrderBy(x => x.Lname).ToList();
                }
                else
                {
                    students = students.OrderByDescending(x => x.Lname).ToList();
                }
            }
            foreach(var student in students)
            {
                Console.WriteLine(student.Fname + " "+student.Lname);
            }
        }
        static void GetStudentsInClass(Labb3DbContext context)
        {
            var classes = context.Courses.ToList();
            var classStudents = (from a in context.CourseConnections
                                 join c in context.Courses on a.CourseId equals c.Id
                                 join d in context.Students on a.StudentId equals d.Id
                                 select new {c.CourseName,d.Fname,d.Lname,a.CourseId}).ToList();
            foreach(var course in classes)
            {
                Console.WriteLine(+course.Id+". "+course.CourseName);
            }
            Console.WriteLine("In wich class do you want to see all the students?\n");
            int Choice=int.Parse(Console.ReadLine());
            var allStudents = classStudents.FindAll(x=>x.CourseId==Choice);
            foreach(var student in allStudents)
            {
                Console.WriteLine(student.CourseName+", "+student.Fname+" "+student.Lname);
            }
        }
        static void AddNewEmployee(Labb3DbContext context)
        {
            var jobType = context.EmploymentTypes.ToList();
            Console.WriteLine("What is the new employees Firstname");
            string firstName = Console.ReadLine();
            Console.WriteLine("What is the new employees Lastname");
            string lastName = Console.ReadLine();
            foreach(var type in jobType)
            {
                Console.WriteLine(type.Id+". "+type.Employment);
            }
            Console.WriteLine("Wich employment type does the new employee have");
            int employeeType=int.Parse(Console.ReadLine());
            var newEmployee = new Employee()
            {
                Fname = firstName,
                Lname = lastName,
                EmploymentId = employeeType
            };
            context.Employees.Add(newEmployee);
            context.SaveChanges();
        }
    }
}