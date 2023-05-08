using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Models
{

    public class StudentRepository : IStudentRepository
    {
        private readonly AppDBContext appDbContext;
        public StudentRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Student> AddStudent(Student student)
        {
            var result  = await appDbContext.Students.AddAsync(student);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteStudent(int studentId)
        {
            var ressult = await appDbContext.Students.FirstOrDefaultAsync(p =>  p.StudentId == studentId);
            if (ressult != null)
            {
                appDbContext.Students.Remove(ressult);

                await appDbContext.SaveChangesAsync();
            }

        }

        public async Task<Student?> GetStudent(int studentId)
        {
            return await appDbContext.Students
                .FirstOrDefaultAsync(p => p.StudentId == studentId);
        }

        public async Task<Student?> GetStudentByEmail(string email)
        {
            return await appDbContext.Students
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await appDbContext.Students.ToListAsync();
        }
        public async Task<IEnumerable<Student>> Search(String? name, Gender? gender)
        {
            IQueryable<Student> query = appDbContext.Students;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name));
                    
            }
            if(gender != null)
            {
                query = query.Where(p => p.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await appDbContext.Students
                                .FirstOrDefaultAsync(p => p.StudentId == student.StudentId);

            if(result != null)
            {
                result.FirstName = student.FirstName;
                result.LastName = student.LastName;
                result.Gender = student.Gender;
                result.Email = student.Email;
                result.DateOfBirth = student.DateOfBirth;
                if(result.DepartmentId != 0)
                {
                    result.DepartmentId = student.DepartmentId;
                }
                result.PhotoPaht = student.PhotoPaht;
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
