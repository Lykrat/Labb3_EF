using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb3_EF.Models
{
    public partial class Labb3DbContext : DbContext
    {
        public Labb3DbContext()
        {
        }

        public Labb3DbContext(DbContextOptions<Labb3DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseConnection> CourseConnections { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-T8D7ORFB; Initial Catalog = Labb3 - School_V2; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<CourseConnection>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CourseConnection");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmploymentId).HasColumnName("EmploymentID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");
            });

            modelBuilder.Entity<EmploymentType>(entity =>
            {
                entity.ToTable("Employment_Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Employment).HasMaxLength(50);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateTime).HasColumnType("date");

                entity.Property(e => e.Grade1)
                    .HasMaxLength(50)
                    .HasColumnName("Grade");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
