using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _15._09._23.CW.DAL.Entity
{
    public class StudentCard
    {
        [Key]
        public string ID { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public virtual Student Student { get; set; }
    }
}
