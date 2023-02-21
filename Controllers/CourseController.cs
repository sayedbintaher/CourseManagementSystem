using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels.CourseVM;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly DataContext _db;

        public CourseController(DataContext db)
        {
            _db = db;
        }
        public IActionResult GetCourses()
        {
            var courses = _db.Courses.ToList();
            return View(courses);
        }

        public IActionResult AddCourse()
        {
            return View(new CreateCourseVM());
        }
        [HttpPost]
        public IActionResult AddCourse(CreateCourseVM model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course()
                {
                    CourseName = model.CourseName,
                    Duration = model.Duration,
                };
                _db.Courses.Add(course);
                if (_db.SaveChanges() > 0)
                {
                    return RedirectToAction("GetCourses");
                }
            }
            return View();
        }
        public IActionResult EditCourse(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var course = _db.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            var courseVM = new EditCourseVM()
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Duration = course.Duration
            };
            return View(courseVM);
        }
        [HttpPost]
        public IActionResult EditCourse(EditCourseVM model)
        {
            if (ModelState.IsValid)
            {
                var course = new Course()
                {
                    Id = model.Id,
                    CourseName = model.CourseName,
                    Duration = model.Duration,
                };
                _db.Courses.Update(course);
                if (_db.SaveChanges() > 0)
                {
                    return RedirectToAction("GetCourses");
                }
            }
            return View();
        }
        public IActionResult DeleteCourse(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var course = _db.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            var courseVM = new DeleteCourseVM()
            {
                Id = course.Id,
                CourseName = course.CourseName,
                Duration = course.Duration
            };
            return View(courseVM);
        }
        [HttpPost]
        public IActionResult DeleteCourse(DeleteCourseVM model)
        {
            var obj = _db.Courses.FirstOrDefault(c => c.Id == model.Id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Courses.Remove(obj);
            if (_db.SaveChanges() > 0)
            {
                return RedirectToAction("GetCourses");
            }

            return View();
        }
        
        
    }
}
