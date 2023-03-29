using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _dataContext;

        public StudentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _dataContext.Students;
            return View(objStudentList);
        }

        public IActionResult Create()
        {
            return View();
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Students.Add(obj);
                _dataContext.SaveChanges();
                TempData["success"] = "Student added successfully";
                return Redirect("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _dataContext.Students.Find(id);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Students.Update(obj);
                _dataContext.SaveChanges();
                TempData["success"] = "Student update successful";
                return Redirect("/Student/Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _dataContext.Students.Find(id);
            if (studentFromDb == null)
            {
                return NotFound();
            }
            return View(studentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(int? id)
        {
            var studentObj = _dataContext.Students.Find(id);
            if(studentObj == null)
            {
                return NotFound();
            }

            _dataContext.Students.Remove(studentObj);
            _dataContext.SaveChanges();
            TempData["success"] = "Student deleted";
            return RedirectToAction("Index");
        }
    }
}
