using Microsoft.EntityFrameworkCore;

namespace test.Models
{
    public class phonebookContext : DbContext
    {
        public phonebookContext(DbContextOptions<phonebookContext> options) : base(options)
        {}
        
        
        public DbSet<phonebookItem> PhonebookItems { get; set; }
    }
}