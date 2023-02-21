using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;

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

        public IActionResult AddBatch()
        {
            return View();
        }
    }
}
