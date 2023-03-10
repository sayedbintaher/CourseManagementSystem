using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels.StudentVM
{
    public class EditStudentVM
    {
        public int Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentId { get; set; }
        [Required(ErrorMessage = "BatchId is required.")]
        public int BatchId { get; set; }
        [Required(ErrorMessage = "CourseId is required.")]
        public int CourseId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ICollection<SelectListItem>? Batches { get; set; }
        public ICollection<SelectListItem>? Courses { get; set; }
    }
}
