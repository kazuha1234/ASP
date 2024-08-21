using Microsoft.EntityFrameworkCore;

namespace HomeWork.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Classroom> classrooms { get; set; }
        public DbSet<Student> students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String conString = "Server=DESKTOP-TV660JG\\SQLEXPRESS;Database=ManageClassroom;Trusted_Connection=True";

            optionsBuilder.UseSqlServer(conString);
        }
    }
}
