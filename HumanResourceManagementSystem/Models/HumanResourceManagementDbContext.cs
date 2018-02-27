/*
* Description: This class depicts components of the human resource management system.
* Author: Zee
* Due date: 27/02/2018
*/
namespace HumanResourceManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// Initializes a new instance of the DbContext class.
    /// </summary>
    public partial class HumanResourceManagementDbContext : DbContext
    {
        public HumanResourceManagementDbContext()
            : base("name=HumanResourceManagementDbContext")
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<CommunicationSkill> CommunicationSkills { get; set; }
        public virtual DbSet<Constituent> Constituents { get; set; }
        public virtual DbSet<Criterion> Criteria { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Network> Networks { get; set; }
        public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .Property(e => e.TargetWorkingHours)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Attendance>()
                .Property(e => e.EmployeeWorkingHours)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Certification>()
                .Property(e => e.GPA)
                .HasPrecision(3, 2);

            modelBuilder.Entity<Criterion>()
                .Property(e => e.CriteriaScore)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Criterion>()
                .HasMany(e => e.Evaluations)
                .WithRequired(e => e.Criterion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Achievements)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.AdministratorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attendances1)
                .WithRequired(e => e.Employee1)
                .HasForeignKey(e => e.EmployeeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Certifications)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CommunicationSkills)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Constituents)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.EPEmployeeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Evaluations)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Evaluations1)
                .WithRequired(e => e.Employee1)
                .HasForeignKey(e => e.EvaluatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Experiences)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Networks)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Performances)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Salaries)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Evaluation>()
                .Property(e => e.GradeAttained)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Network>()
                .Property(e => e.ContactsNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<Performance>()
                .Property(e => e.KPI)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Performance>()
                .Property(e => e.Discipline)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Performance>()
                .HasMany(e => e.Constituents)
                .WithRequired(e => e.Performance)
                .HasForeignKey(e => e.EPPerformanceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Salary>()
                .Property(e => e.BasicSalary)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Salary>()
                .Property(e => e.PerformanceBasedSalary)
                .HasPrecision(7, 2);
        }
    }
}
