using HomeWork.Models;

namespace HomeWork.ViewModel
{
    public class StudentViewModel
    {
        public string keyWord { get; set; }
        public List<Student> students { get; set; }
        public Student selectedStudent { get; set; }
        public String ClassName { get; set; }
    }
}
