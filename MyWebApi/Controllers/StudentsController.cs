using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository? studentRepository;
        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        [HttpGet("{Search}")]
        public async Task<ActionResult<IEnumerable<Student>>> Search(string name, Gender? gender)
        {
            try
            {
                var result = await studentRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await studentRepository.GetStudents());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retieving data from the database");

            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            try
            {
                var result = await studentRepository.GetStudent(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retieving data from the database");

            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }
                var stu = await studentRepository.GetStudentByEmail(student.Email);
                if (stu != null)
                {
                    ModelState.AddModelError("Email", "Student Email already use");
                    return BadRequest(ModelState);
                }
                var createStudent = await studentRepository.AddStudent(student);
                return CreatedAtAction(nameof(GetStudent),
                    new { id = createStudent.StudentId }, createStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new student record");

            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id,  Student student)
        {
            try
            {
                if(id != student.StudentId)
                {
                    return BadRequest("Student Id mismatch");
                }
                var studentToUpdate = await studentRepository.GetStudent(id);
                if (studentToUpdate == null)
                {
                    return NotFound($"Student with id = {id} not found");
                }
                return await studentRepository.UpdateStudent(student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating student record");

            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                var studentToDelete = await studentRepository.GetStudent(id);
                if(studentToDelete == null)
                {
                    return NotFound($"Student with id {id} not found");

                }
                await studentRepository.DeleteStudent(id);
                return Ok($"Student with id {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting Student record");

            }
        }

    }
}
