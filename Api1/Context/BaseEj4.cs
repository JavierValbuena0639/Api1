using Microsoft.EntityFrameworkCore;
using Api1.Model;

namespace Api1.Context
{
    public class BaseEj4 : DbContext
    {
        public BaseEj4(DbContextOptions<BaseEj4> options) : base(options)
        {

        }

        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Departaments> Departments { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<TimeDedicated> TimeDedicated { get; set; }
    }
}
