using System.ComponentModel.DataAnnotations;

namespace _15._09._23.CW.DAL.Entity
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Phone { get; set; }
        public StudentCard StudentCard { get; set; }
    }
}
