namespace MyWebApi.Models
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Search(String? name, Gender? gender);
        Task<Student?> GetStudent(int studentId);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudentByEmail(String? email);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudent(int studentId);
    }
}
