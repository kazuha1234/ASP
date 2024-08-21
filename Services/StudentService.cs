using HomeWork.Models;
using System.Diagnostics.Eventing.Reader;

namespace HomeWork.Services
{
    public class StudentService
    {
        AppDBContext db;

        public StudentService()
        {
            this.db = new AppDBContext();
        }

        public List<Student> GetAll()
        {
            var obj = db.students.ToList();

            return obj;
        }

        public List<Student> GetByClassId(int id)
        {
            List<Student> obj = db.students.Where(x => x.ClassroomId == id).ToList();

            return obj;
        }

        public Student GetById(int id)
        {
            var obj = db.students.Where(x => x.Id == id).FirstOrDefault();

            return obj;
        }

        public List<Student> GetByName(string name, int id)
        {
            List<Student> obj = db.students.Where(x => (x.Name.Contains(name) ||
                                                       x.StudentId.Contains(name)) &&
                                                       x.ClassroomId == id
                                                       ).ToList();

            return obj;
        }

        public bool Insert(Student student)
        {
            var existingStudent = db.students.Where(x => x.StudentId == student.StudentId).FirstOrDefault();

            if (existingStudent == null)
            {
                db.students.Add(student);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(Student student)
        {
            var obj = db.students.Where(x => x.StudentId == student.StudentId).FirstOrDefault();

            if(obj != null)
            {
                obj.Name = student.Name;
                obj.BirthDate = student.BirthDate;
                obj.Gender = student.Gender;
                obj.ClassroomId = student.ClassroomId;

                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var obj = db.students.Where(x => x.Id == id).FirstOrDefault();

            if (obj != null)
            {
                db.students.Remove(obj);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
