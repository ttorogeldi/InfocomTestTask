using System.ComponentModel.DataAnnotations;

namespace InfocomTestTask.Models
{
    public class Person
    {  
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Name is long 50")]
        public string SureName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name is long 50")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
        public Gender Sex { get; set; }


    }
    public enum Gender : int
    {
        Unknow,
        Male,
        Female
    }
}
