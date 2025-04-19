using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models
{
    public class MartDb : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public MartDb(DbContextOptions<MartDb> options) : base(options)
        {
        }
    }
}