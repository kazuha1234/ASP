using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork.Models
{
    [Table("Classrooms")]
    public class Classroom
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Room { get; set; }

        public virtual List<Student> Students { get; set;} 
    }
}
