using StudentAPI.Models;

namespace StudentAPI.DataSimulation
{
    public class StudentDataSimulation
    {
        public static readonly List<Student> StudentsList = new List<Student>
        {
            new Student
            {
                Id= 1,
                Name = "Ahmed Ali",
                Age = 20,
                Grade = 60
            },
            new Student
            {
                Id = 2,
                Name = "Ali Ahmed",
                Age = 23,
                Grade = 30
            },
            new Student
            {
                Id = 3,
                Name = "Moustafa Mouhamed",
                Age = 18,
                Grade = 70
            },
            new Student
            {
                Id = 4,
                Name = "Moustafa Mouhamed",
                Age = 25,
                Grade = 75
            }
        };
    }
}
