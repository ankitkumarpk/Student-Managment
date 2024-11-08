using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Models;
using StudentRegistration.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRegistration.Controllers // Updated namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<ResultModel<IEnumerable<Student>>>> Get()
        {
            var result = await _studentService.GetAllStudentsAsync();
            return Ok(result); // Returns the ResultModel with a 200 OK response
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultModel<Student>>> Get(int id)
        {
            var result = await _studentService.GetStudentByIdAsync(id);
            if (!result.Success)
            {
                return NotFound(new { Message = result.Message }); // Return 404 with message if not found
            }
            return Ok(result); // Return the ResultModel with a 200 OK response
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student value)
        {
            if (value == null)
            {
                return BadRequest("Student data is required.");
            }

            var result = await _studentService.AddStudentAsync(value);
            return CreatedAtAction(nameof(Get), new { id = result.Model }, result); // Return the created ResultModel
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student value)
        {
            if (value == null)
            {
                return BadRequest("Student data is required.");
            }

            var existingStudent = await _studentService.GetStudentByIdAsync(id);
            if (!existingStudent.Success)
            {
                return NotFound(new { Message = existingStudent.Message }); // Return 404 with message if not found
            }

            var updateResult = await _studentService.UpdateStudentAsync(id, value);
            if (!updateResult.Success)
            {
                return BadRequest(updateResult.Message); // Handle update errors
            }

            return NoContent(); // Return 204 No Content on successful update
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingStudent = await _studentService.GetStudentByIdAsync(id);
            if (!existingStudent.Success)
            {
                return NotFound(new { Message = existingStudent.Message }); // Return 404 with message if not found
            }

            var deleteResult = await _studentService.DeleteStudentAsync(id);
            if (!deleteResult.Success)
            {
                return BadRequest(deleteResult.Message); // Handle delete errors
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
