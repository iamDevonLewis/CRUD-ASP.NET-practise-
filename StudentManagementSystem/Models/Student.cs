using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
       
        [Range(1,50, ErrorMessage ="Display order must be between 1-100")]
        public int Age { get; set; }
        [DisplayName("Enrollment Date")]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
