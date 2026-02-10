using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }
        public List<Student> ActiveStudents{get; private set;}

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
            ActiveStudents = new List<Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            // TODO:
            // 1. Throw ArgumentException if course code exists
            if(AvailableCourses.ContainsKey(code))
            {
                throw new ArugumentException("Course code already exists.");
            }
            // 2. Create Course object
            Course course = new Course(code,name,credits,maxCapacity,prerequisites);
            // 3. Add to AvailableCourses
            AvailableCourses.add(code,course);
            throw new NotImplementedException();
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            // TODO:
            // 1. Throw ArgumentException if student ID exists
            if(Students.ContainsKey(id))
            {
                throw new ArgumentException("Student ID already exists.");
            }
            // 2. Create Student object
            Student student = new Student(id,name,major,maxCredits,completedCourses);
            Srudents.Add(id,student);
            ActiveStudents.Add(student);
            // 3. Add to Students dictionary
            throw new NotImplementedException();
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student and course existence
            if(!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found");
                return false;
            }
            // 2. Call student.AddCourse(course)
            if(!AvailableCourses.ContainsKey(courseCode))
            {
                Console.WriteLine("Course not found.");
                return false;
            }
            // 3. Display meaningful messages

            Student student = Students[studentId];
            Course course = AvailableCourses[courseCode];

            if(!student.CanAddCourse(course))
            {
                Console.WriteLine("Cannot register: credit limit exceeded, prerequisites not met, or already registered.");
                return false;
            }

            if(course.IsFull())
            {
                Console.WriteLine("Cannot register :  course is full");
                return false;
            }

            student.AddCourse(course);
            return true;
            throw new NotImplementedException();
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            // TODO:
            // 1. Validate student existence
            // 2. Call student.DropCourse(courseCode)
            throw new NotImplementedException();
        }

        public void DisplayAllCourses()
        {
            Console.WriteLine("Available Courses :");

            foreach(Course course in AvailableCourses.Values)
            {
                Console.WriteLine(
                    $"{course.CourseCode}-{course.CourseName}"+
                    $"({course.Credits} credits)"+
                    $"[{course.GetEnrollmentInfo()}]"
                );
            }
            // TODO:
            // Display course code, name, credits, enrollment info
            throw new NotImplementedException();
        }

        public void DisplayStudentSchedule(string studentId)
        {
            // TODO:
            // Validate student existence
            // Call student.DisplaySchedule()
            if(!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Students[studentId].DisplaySchedule();
            throw new NotImplementedException();
        }

        public void DisplaySystemSummary()
        {
            // TODO:
            int totalStudents = ActiveStudents.Count;
            int totalCourses = AvailableCourses.Count;

            double averageEnrollment = 0;
            if(totalCourses > 0)
            {
                averageEnrollment = AvailableCourses.Values.Average(c =>double.parse(c.GetEnrollmentinfo().Split('/')[0]));
            }
            // Display total students, total courses, average enrollment
            Console.WriteLine("Syste, Summary :");
            Console.WriteLine($"Total Students : {totalStudents}");
            Console.WriteLine($"Total Courses : {totalCourses}");
            Console.WriteLine($"Average Enrollment: {averageEnrollment :F2}");
            throw new NotImplementedException();
        }
    }
}
