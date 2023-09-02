using System.ComponentModel.DataAnnotations;

namespace MvcStudCrud.Models
{
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Percentage { get; set; }
        [Required]
        public DateTime dob { get; set; }
        [ScaffoldColumn(false)]
        public int isActive { get; set; }
    }
}
