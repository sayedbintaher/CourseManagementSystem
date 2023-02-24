using CourseManagementSystem.ViewModels.BatchVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels.BatchVM;
using SchoolManagementSystem.ViewModels.CourseVM;

namespace SchoolManagementSystem.Controllers
{
    [Authorize]
    public class BatchController : Controller
    {
        private readonly DataContext _db;

        public BatchController( DataContext db)
        {
            _db = db;
        }
        public IActionResult GetBatches()
        {
            var batches = _db.Batches.ToList();
            return View(batches);
        }

        public IActionResult CreateBatch()
        {
            return View(new CreateBatchVM());
        }

        [HttpPost]
        public IActionResult CreateBatch(CreateBatchVM model)
        {
            if (ModelState.IsValid)
            {
                var batch = new Batch()
                {
                    BatchCode= model.BatchCode,
                    Year=model.Year
                };
                _db.Batches.Add(batch);
                if(_db.SaveChanges() > 0)
                {
                    RedirectToAction("GetBatches");
                }
            }
            return View();
        }
        public IActionResult EditBatch(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var batch = _db.Batches.FirstOrDefault(b => b.Id == id);
            if (batch == null)
            {
                return NotFound();
            }
            var batchVM = new EditBatchVM()
            {
                Id = batch.Id,
                BatchCode = batch.BatchCode,
                Year = batch.Year
            };
            return View(batchVM);

        }
        [HttpPost]
        public IActionResult EditBatch(EditBatchVM model)
        {
            if (ModelState.IsValid)
            {
                var batch = new Batch()
                {
                    Id = model.Id,
                    BatchCode = model.BatchCode,
                    Year = model.Year
                };
                _db.Batches.Update(batch);
                if (_db.SaveChanges() > 0)
                {
                    return RedirectToAction("GetBatches");
                }
            }
            return View();
        }
        public IActionResult DeleteBatch(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var course = _db.Batches.FirstOrDefault(b => b.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            var courseVM = new DeleteBatchVM()
            {
                Id = course.Id,
                BatchCode = course.BatchCode,
                Year = course.Year
            };
            return View(courseVM);
        }
        [HttpPost]
        public IActionResult DeleteBatch(DeleteBatchVM model)
        {
            var obj = _db.Batches.FirstOrDefault(b => b.Id == model.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Batches.Remove(obj);
            if (_db.SaveChanges() > 0)
            {
                return RedirectToAction("GetBatches");
            }

            return View();
        }
    }
}
