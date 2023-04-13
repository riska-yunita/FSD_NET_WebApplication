using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FSD_NET_WebApplication.Context;

public class MyContext : DbContext
{
    public DbSet<Universities> TB_M_Universities { get; set; }
    public DbSet<Employees> TB_M_Employees { get; set; }
    public DbSet<Roles> TB_M_Roles { get; set; }
    public DbSet<Educations> TB_M_Educations { get; set; }
    public DbSet<AccountRoles> TB_TR_Account_Roles { get; set; }
    public DbSet<Profilings> TB_TR_Profiling { get; set; }
    public DbSet<Accounts> TB_M_Accounts { get; set; }

    public MyContext(DbContextOptions<MyContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Relasi One University to Many Education
        modelBuilder.Entity<Universities>()
            .HasMany(u => u.Educations)
            .WithOne(e => e.Universities)
            .HasForeignKey(u => u.UniversityId)
            .OnDelete(DeleteBehavior.NoAction);

        //Relasi One Educations to One Profilings
        modelBuilder.Entity<Educations>()
            .HasOne(u => u.Profilings)
            .WithOne(e => e.Educations)
            .HasForeignKey<Profilings>(e => e.EducationId)
            .OnDelete(DeleteBehavior.NoAction);

        //Relasi One Roles to Many Account Roles
        modelBuilder.Entity<Roles>()
            .HasMany(u => u.AccountRoles)
            .WithOne(e => e.Roles)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.NoAction);

        //Relasi One Account to Many Account Roles
        modelBuilder.Entity<Accounts>()
            .HasMany(u => u.AccountRoles)
            .WithOne(e => e.Accounts)
            .HasForeignKey(u => u.AccountNIK)
            .OnDelete(DeleteBehavior.NoAction);

        //Relasi One Accounts to One Employees
        modelBuilder.Entity<Employees>()
            .HasOne(u => u.Accounts)
            .WithOne(e => e.Employees)
            .HasForeignKey<Accounts>(e => e.EmployeeNIK)
            .OnDelete(DeleteBehavior.NoAction);

        //Relasi One Profilings to One Employees
        modelBuilder.Entity<Employees>()
            .HasOne(u => u.Profilings)
            .WithOne(e => e.Employees)
            .HasForeignKey<Profilings>(e => e.EmployeeNIK)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<RegisterVM>()
            .HasNoKey();
        modelBuilder.Entity<LoginVM>()
            .HasNoKey();
    }

    public DbSet<FSD_NET_WebApplication.ViewModel.RegisterVM>? RegisterVM { get; set; }

    public DbSet<FSD_NET_WebApplication.ViewModel.LoginVM>? LoginVM { get; set; }
}