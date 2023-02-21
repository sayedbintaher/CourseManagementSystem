using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.ViewModels.StudentVM
{
    public class ShowStudentVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentId { get; set; }
        public Batch Batch { get; set; }
        public Course Course { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }

    }
}
