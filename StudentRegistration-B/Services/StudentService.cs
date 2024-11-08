using Dapper;
using MySql.Data.MySqlClient;
using StudentRegistration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentRegistration.Services
{
    public class StudentService : IStudentService
    {
        private readonly string _connectionString;

        public StudentService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ResultModel<IEnumerable<Student>>> GetAllStudentsAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var students = await connection.QueryAsync<Student>("SELECT * FROM Students");

                return new ResultModel<IEnumerable<Student>>
                {
                    Model = students,
                    MsgCode = 1,
                    Message = "Students retrieved successfully"
                };
            }
        }

        public async Task<ResultModel<Student>> GetStudentByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var student = await connection.QuerySingleOrDefaultAsync<Student>("SELECT * FROM Students WHERE Id = @Id", new { Id = id });

                if (student == null)
                {
                    return new ResultModel<Student>
                    {
                        Success = false,
                        MsgCode = 404,
                        Message = "Student not found"
                    };
                }

                return new ResultModel<Student>
                {
                    Model = student,
                    MsgCode = 1,
                    Message = "Student retrieved successfully"
                };
            }
        }

        public async Task<ResultModel<int>> AddStudentAsync(Student student)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var sql = "INSERT INTO Students (FirstName, MiddleName, LastName, DateOfBirth, Gender, JoiningDate, Email, Password) VALUES (@FirstName, @MiddleName, @LastName, @DateOfBirth, @Gender, @JoiningDate, @Email, @Password); SELECT LAST_INSERT_ID();";
                var newId = await connection.ExecuteScalarAsync<int>(sql, student);

                return new ResultModel<int>
                {
                    Model = newId,
                    MsgCode = 1,
                    Message = "Student added successfully"
                };
            }
        }

        public async Task<ResultModel<bool>> UpdateStudentAsync(int id, Student student)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "UPDATE Students SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, DateOfBirth = @DateOfBirth, Gender = @Gender, JoiningDate = @JoiningDate, Email = @Email, Password = @Password WHERE Id = @Id";

                student.Id = id; // Ensure we set the Id for the update
                var affectedRows = await connection.ExecuteAsync(sql, student);

                if (affectedRows == 0)
                {
                    return new ResultModel<bool>
                    {
                        Success = false,
                        MsgCode = 404,
                        Message = "Student not found"
                    };
                }

                return new ResultModel<bool>
                {
                    Model = true,
                    MsgCode = 1,
                    Message = "Student updated successfully"
                };
            }
        }

        public async Task<ResultModel<bool>> DeleteStudentAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var affectedRows = await connection.ExecuteAsync("DELETE FROM Students WHERE Id = @Id", new { Id = id });

                if (affectedRows == 0)
                {
                    return new ResultModel<bool>
                    {
                        Success = false,
                        MsgCode = 404,
                        Message = "Student not found"
                    };
                }

                return new ResultModel<bool>
                {
                    Model = true,
                    MsgCode = 1,
                    Message = "Student deleted successfully"
                };
            }
        }
    }
}
