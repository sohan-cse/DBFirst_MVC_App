using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirst_MVC_App.Models;

public partial class StudentDataBaseContext : DbContext
{
    public StudentDataBaseContext()
    {
    }

    public StudentDataBaseContext(DbContextOptions<StudentDataBaseContext> options)
        : base(options)
    {
    }

    //This line represents the Student table in the database and allows EF Core to query, insert, update, and delete student records using C#.
    public virtual DbSet<Student> Students { get; set; }
    //DbSet represents a database table and provides methods to query and manipulate data using EF Core.

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//    => optionsBuilder.UseSqlServer("Server=SOHAN\\SQLEXPRESS;Database=StudentDataBase;trusted_connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Student__85FB4E38CD689CD4").IsUnique();

            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
