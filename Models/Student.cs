using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string StudentId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        
        public DateTime BirthDate { get; set; }

        public EGender Gender { get; set; }

        public int ClassroomId { get; set; }

        [ForeignKey("ClassroomId")]
        public Classroom Classroom { get; set; }
    }

    public enum EGender
    {
        Nam, Nu, Khac
    }
}
