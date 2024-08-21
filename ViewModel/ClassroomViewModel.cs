using HomeWork.Models;

namespace HomeWork.ViewModel
{
    public class ClassroomViewModel
    {
        public List<Classroom> listClassroom { get; set; }
        public string keyWord { get; set; }
        public Classroom selectedClassroom { get; set; }

        public List<Student> listStudent { get; set; }
        public Classroom classroomCurrent { get; set; }
    }
}
