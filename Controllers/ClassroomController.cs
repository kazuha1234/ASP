using HomeWork.Models;
using HomeWork.Services;
using HomeWork.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork.Controllers
{
    public class ClassroomController : Controller
    {
        ClassroomService classroomService;
        StudentService studentService;

        public ClassroomController()
        {
            this.classroomService = new ClassroomService();
            this.studentService = new StudentService();
        }

        public IActionResult Index(string keyWord)
        {
            ClassroomViewModel model = new ClassroomViewModel();
            List<Classroom> classrooms = new List<Classroom>();

            if(string.IsNullOrEmpty(keyWord))
            {
                classrooms = classroomService.GetAll();
            }
            else
            {
                classrooms = classroomService.GetByName(keyWord);
                model.keyWord = keyWord;
            }

            model.listClassroom = classrooms;

            return View(model);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(ClassroomViewModel classroom)
        {
            classroomService.Insert(classroom.selectedClassroom);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ClassroomViewModel model = new ClassroomViewModel();
            Classroom obj = new Classroom();

            obj = classroomService.GetById(id);
            model.selectedClassroom = obj;

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(ClassroomViewModel classroom)
        {
            classroomService.Update(classroom.selectedClassroom);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            classroomService.Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            ClassroomViewModel model = new ClassroomViewModel();
            model.listStudent = studentService.GetByClassId(id);
            model.classroomCurrent = classroomService.GetById(id);

            return PartialView("Detail", model);
        }

        [HttpPost]
        public IActionResult Insert2([FromBody] ClassroomViewModel classroom)
        {
            if (classroom?.selectedClassroom != null)
            {
                classroomService.Insert(classroom.selectedClassroom);
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Invalid data" });
        }
    }
}
