using System.Collections.Generic;
using System.Threading.Tasks;
using StudentRegistration.Models;

namespace StudentRegistration.Services
{
    public interface IStudentService
    {
        Task<ResultModel<IEnumerable<Student>>> GetAllStudentsAsync(); // Change to List<Student>
        Task<ResultModel<Student>> GetStudentByIdAsync(int id);
        Task<ResultModel<int>> AddStudentAsync(Student student);
        Task<ResultModel<bool>> UpdateStudentAsync(int id, Student student);
        Task<ResultModel<bool>> DeleteStudentAsync(int id);
    }
}
