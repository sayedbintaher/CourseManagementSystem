using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentId { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set;}      
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
