using lmsapp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<LeaveBalance> LeaveBalances { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Dashboard> Dashboards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships and constraints if needed
        modelBuilder.Entity<LeaveRequest>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(lr => lr.EmployeeId);

        modelBuilder.Entity<LeaveRequest>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(lr => lr.ManagerId);

        modelBuilder.Entity<LeaveBalance>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(lb => lb.EmployeeId);

        modelBuilder.Entity<Notification>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(n => n.EmployeeId);

        modelBuilder.Entity<Notification>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(n => n.ManagerId);

        modelBuilder.Entity<Dashboard>()
            .HasKey(d => d.Id); // Define primary key for Dashboard
    }
}
