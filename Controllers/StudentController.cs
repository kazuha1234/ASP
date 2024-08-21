using HomeWork.Models;
using HomeWork.Services;
using HomeWork.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    public class StudentController : Controller
    {
        StudentService studentService;
        ClassroomService ClassroomService { get; set; }

        public StudentController()
        {
            this.studentService = new StudentService();
            this.ClassroomService = new ClassroomService();
        }

        public IActionResult Index(string keyWord, int id)
        {
            List<Student> students = new List<Student>();
            StudentViewModel model = new StudentViewModel();

            if (string.IsNullOrEmpty(keyWord))
            {
                students = studentService.GetByClassId(id);
            }
            else
            {
                students = studentService.GetByName(keyWord, id);
                model.keyWord = keyWord;
            }
            model.students = students;

            return View(model);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(StudentViewModel student)
        {
            studentService.Insert(student.selectedStudent);

            return RedirectToAction("Index", new { id = student.selectedStudent.ClassroomId });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Student student = studentService.GetById(id);
            StudentViewModel model = new StudentViewModel();

            model.selectedStudent = student;

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(StudentViewModel student)
        {
            studentService.Update(student.selectedStudent);

            return RedirectToAction("Index", new { id = student.selectedStudent.ClassroomId });
        }

        public IActionResult Delete(int id)
        {
            Student student = studentService.GetById(id);
            studentService.Delete(id);

            return RedirectToAction("Index", new { id = student.ClassroomId });
        }
    }
}
