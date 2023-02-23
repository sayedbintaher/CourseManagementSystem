using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels.StudentVM;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly DataContext _db;

        public StudentController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var models = _db.Students.Include(s => s.Course).Include(s => s.Batch).ToList();
            
            var showStudentVm = models.Select(m => new ShowStudentVM()
            {
                Id= m.Id,
                FirstName= m.FirstName,
                LastName= m.LastName,
                StudentId= m.StudentId,
                Batch = m.Batch,
                Course = m.Course,
                Phone = m.Phone,
                Address = m.Address

            });
            return View(showStudentVm);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            var batches = _db.Batches.Select(b => new SelectListItem()
            {
                Text = b.BatchCode,
                Value = b.Id.ToString()
            }).ToList();

            var courses = _db.Courses.Select(c => new SelectListItem()
            {
                Text = c.CourseName,
                Value = c.Id.ToString()
            }).ToList();

            var studentCreateVm = new CreateStudentVM()
            {
                Batches = batches,
                Courses = courses
            };
            return View(studentCreateVm);
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentVM model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StudentId = model.StudentId,
                    BatchId = model.BatchId,
                    CourseId = model.CourseId,
                    Phone = model.Phone,
                    Address = model.Address
                };
                _db.Students.Add(student);
                if (_db.SaveChanges() > 0)
                {
                    return RedirectToAction("GetStudents");
                }
            }

            return View();
        }

        public IActionResult EditStudent(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var batches = _db.Batches.Select(b => new SelectListItem()
            {
                Text = b.BatchCode,
                Value = b.Id.ToString()
            }).ToList();

            var courses = _db.Courses.Select(c => new SelectListItem()
            {
                Text = c.CourseName,
                Value = c.Id.ToString()
            }).ToList();

            var studentEditVm = new EditStudentVM()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentId = student.StudentId,
                BatchId = student.BatchId,
                CourseId = student.CourseId,
                Phone = student.Phone,
                Address = student.Address,
                Batches = batches,
                Courses = courses
            };
            return View(studentEditVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStudent(EditStudentVM editedStudent)
        {
            if (ModelState.IsValid)
            {
                var student = new Student()
                {
                    Id = editedStudent.Id,
                    FirstName = editedStudent.FirstName,
                    LastName = editedStudent.LastName,
                    StudentId = editedStudent.StudentId,
                    BatchId = editedStudent.BatchId,
                    CourseId = editedStudent.CourseId,
                    Phone = editedStudent.Phone,
                    Address = editedStudent.Address
                };
                _db.Students.Update(student);
                if (_db.SaveChanges() > 0)
                {
                    return RedirectToAction("GetStudents");
                }
            }
            return View();
        }
        public IActionResult DeleteStudent(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var batches = _db.Batches.Select(b => new SelectListItem()
            {
                Text = b.BatchCode,
                Value = b.Id.ToString()
            }).ToList();

            var courses = _db.Courses.Select(c => new SelectListItem()
            {
                Text = c.CourseName,
                Value = c.Id.ToString()
            }).ToList();

            var studentDeleteVm = new DeleteStudentVM()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentId = student.StudentId,
                BatchId = student.BatchId,
                CourseId = student.CourseId,
                Phone = student.Phone,
                Address = student.Address,
                Batches = batches,
                Courses = courses
            };
            return View(studentDeleteVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudent(DeleteStudentVM deleteStudentVM)
        {
            var obj = _db.Students.FirstOrDefault(c => c.Id == deleteStudentVM.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            if (_db.SaveChanges() > 0)
            {
                return RedirectToAction("GetStudents");
            }

            return View();
        }
    }
}
