using Microsoft.EntityFrameworkCore;
using Attendence_Leave_Management.Model;

namespace Attendence_Leave_Management.Model
{
    public class Attendance_Leave_Context:DbContext
    {
        public Attendance_Leave_Context(DbContextOptions<Attendance_Leave_Context> options):base(options)
        {
            
        }
        public virtual DbSet<Attendance> AttendenceData { get; set; }

        public virtual DbSet<Employees> EmployeeData { get; set; }

        public virtual DbSet<Leaves> LeaveData { get; set; }

        public virtual DbSet<Manager> ManagerData { get; set; }

        public virtual DbSet<Project> ProjectData { get; set; }

        public DbSet<Attendence_Leave_Management.Model.Admin>? Admin { get; set; }
    }
}
