using BasicCrud_Vargas_Adrian.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud_Vargas_Adrian.Data
{
    public class BasicCrud : DbContext
    {
        public BasicCrud(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
