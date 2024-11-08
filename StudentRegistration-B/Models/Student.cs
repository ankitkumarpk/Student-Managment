namespace StudentRegistration.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
