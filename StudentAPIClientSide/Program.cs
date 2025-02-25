using System.Net.Http.Json;

namespace StudentAPIClientSide
{
    internal class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5014/api/Students");
            await GetAllStudents();
            await GetPassedStudents();
        }
        static async Task GetAllStudents()
        {
            try
            {
                Console.WriteLine("\n______________________________\n");
                Console.WriteLine("\nFetching All Students..");
                var students = await httpClient.GetFromJsonAsync<List<Student>>("All");
                if (students != null)
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
                    }
                }
                else
                {
                    Console.WriteLine("No Students Found");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An Error Accoured : {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }


        }

        static async Task GetPassedStudents()
        {
            try
            {
                Console.WriteLine("\n______________________________\n");
                Console.WriteLine("\nFetching All Passed Students..");
                var students = await httpClient.GetFromJsonAsync<List<Student>>("Passed");
                if (students != null)
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
                    }
                }
                else
                {
                    Console.WriteLine("No Students Found");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An Error Accoured : {ex.Message}");
            }


        }
    }
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }
    }
}

