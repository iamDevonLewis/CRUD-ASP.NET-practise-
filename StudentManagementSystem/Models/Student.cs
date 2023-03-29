using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Name")]
        [Range(1,100, ErrorMessage ="Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
