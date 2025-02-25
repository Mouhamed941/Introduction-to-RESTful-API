using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.DataSimulation;
namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/Students")]
    
    public class StudentsController : ControllerBase
    {
        [HttpGet("All")]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(StudentDataSimulation.StudentsList);
        }

        [HttpGet("Passed",Name ="GetPassedStudents")]
        public ActionResult<IEnumerable<Student>> GetPassedStudents()
        {
            var passedStudents = StudentDataSimulation.StudentsList.FindAll(student => student.Grade >= 50);
            return Ok(passedStudents);
        }
    }
}
