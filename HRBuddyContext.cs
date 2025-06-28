using Microsoft.EntityFrameworkCore;

public class HRBuddyContext : DbContext
{
    public HRBuddyContext(DbContextOptions<HRBuddyContext> options) : base(options) {}
    public DbSet<Employee> Employees { get; set; }
}