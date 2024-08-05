using Microsoft.EntityFrameworkCore;

namespace Curd_Dot_Net_Api.Data
{
    public class DpappCon : DbContext
    {
        public DpappCon(DbContextOptions<DpappCon> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
