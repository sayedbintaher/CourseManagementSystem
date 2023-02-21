using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BatchCode { get; set; }
        public string Year { get; set; }
        public List<Student>? Students { get; set; }
    }
}
