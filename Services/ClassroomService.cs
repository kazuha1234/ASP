using HomeWork.Models;

namespace HomeWork.Services
{
    public class ClassroomService
    {
        AppDBContext db;

        public ClassroomService()
        {
            this.db = new AppDBContext();
        }

        public List<Classroom> GetAll()
        {
            var obj = db.classrooms.ToList();

            return obj;
        }

        public Classroom GetById(int id)
        {
            var obj = db.classrooms.Where(x => x.Id == id).FirstOrDefault();

            return obj;
        }

        public List<Classroom> GetByName(string name)
        {
            List<Classroom> obj = db.classrooms.Where(x => x.Name.Contains(name)).ToList();

            return obj;
        }

        public bool Insert(Classroom classroom)
        {
            db.classrooms.Add(classroom);
            db.SaveChanges();

            return true;
        }

        public bool Update(Classroom classroom)
        {
            var obj = db.classrooms.Where(x => x.Id == classroom.Id).FirstOrDefault();

            if(obj != null)
            {
                obj.Name = classroom.Name;
                obj.Room = classroom.Room;
                obj.Students = classroom.Students;
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            var obj = db.classrooms.Where(x => x.Id == id).FirstOrDefault();

            if(obj != null)
            {
                db.classrooms.Remove(obj);
                db.SaveChanges();
            }

            return true;
        }
    }
}
