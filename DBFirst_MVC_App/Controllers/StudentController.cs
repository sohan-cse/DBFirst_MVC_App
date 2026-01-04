using DBFirst_MVC_App.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DBFirst_MVC_App.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDataBaseContext _context;

        public StudentController(StudentDataBaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //It reads all rows from the Student table, converts them into a list of Student objects, and stores them in the students variable.
            List<Student> students = _context.Students.ToList();
            return View(students);
        }
        public IActionResult Details(int id)
        {
            if (id == null || id == 0)
            {
                TempData["error"] = "Please Enter Student Id";
                return RedirectToAction("Index");
            }
            //It retrieves a single Student object from the database based on the provided id parameter.
            Student student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                TempData["error"] = "Invalid Student Id";
                return RedirectToAction("Index");
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                TempData["success"] = "Student created successfully.";
                return RedirectToAction("Index");
            }
            return View(student);
        }
        //public IActionResult Create(Student student)
        //{
        //    if (student == null)
        //    {
        //        TempData["error"] = "Student data is null.";
        //        return RedirectToAction("Index");
        //    }
        //    _context.Students.Add(student);
        //    _context.SaveChanges();
        //    TempData["success"] = "Student created successfully.";
        //    return RedirectToAction("Index");
        //}
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id!=null)
            {
                Student student = _context.Students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
                    return View(student);
                }
                TempData["error"] = "Invalid Student Id";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Invalid Student Id";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                TempData["success"] = "Student updated successfully.";
                return RedirectToAction("Index");
            }
            TempData["error"]= "Failed to update student. Please check the input data.";
            return View(student);
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Student student = _context.Students.FirstOrDefault(s => s.Id == id);
                if (student != null)
                {
                   
                    return View(student);
                }
                TempData["error"] = "Invalid Student Id";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Invalid Student Id";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Student student)
        { 
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                TempData["success"] = "Student deleted successfully.";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Failed to delete student. Please try again.";
            return RedirectToAction("Index");
        }
    }
}
