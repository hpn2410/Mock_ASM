using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class MockAsmContext : DbContext
{
    public MockAsmContext()
    {
    }

    public MockAsmContext(DbContextOptions<MockAsmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentInfo> StudentInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Mock_ASM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__FDF4798613B0ABE7");

            entity.ToTable("Class");

            entity.HasIndex(e => e.ClassCode, "UQ__Class__0AF9B2E4A3BA1D7A").IsUnique();

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ClassCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("class_code");

            entity.HasMany(d => d.Instructors).WithMany(p => p.Classes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassInstructor",
                    r => r.HasOne<Instructor>().WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Class_Ins__instr__35BCFE0A"),
                    l => l.HasOne<Class>().WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Class_Ins__class__34C8D9D1"),
                    j =>
                    {
                        j.HasKey("ClassId", "InstructorId").HasName("PK__Class_In__67EA8CE811DF3DF7");
                        j.ToTable("Class_Instructor");
                        j.IndexerProperty<int>("ClassId").HasColumnName("class_id");
                        j.IndexerProperty<int>("InstructorId").HasColumnName("instructor_id");
                    });
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__A1EF56E82CAFDCB3");

            entity.ToTable("Instructor");

            entity.HasIndex(e => e.Email, "UQ__Instruct__AB6E6164A2065F42").IsUnique();

            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.InstructorName)
                .HasMaxLength(100)
                .HasColumnName("instructor_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__2A33069AECCB0CEF");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.StudentCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("student_code");
            entity.Property(e => e.StudentInfoId).HasColumnName("student_info_id");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__class_i__2F10007B");

            entity.HasOne(d => d.StudentInfo).WithMany(p => p.Students)
                .HasForeignKey(d => d.StudentInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__student__2E1BDC42");
        });

        modelBuilder.Entity<StudentInfo>(entity =>
        {
            entity.HasKey(e => e.StudentInfoId).HasName("PK__Student___8E40FB55BA9B17B1");

            entity.ToTable("Student_Info");

            entity.HasIndex(e => e.Email, "UQ__Student___AB6E61649A2245A9").IsUnique();

            entity.Property(e => e.StudentInfoId).HasColumnName("student_info_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .HasColumnName("student_name");
        });

        OnModelCreatingPartial(modelBuilder);
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentInfo>().HasData(
                new StudentInfo { StudentInfoId = 1, StudentName = "NguyenDZ",
                    DateOfBirth = new DateTime(2002, 5, 12, 0, 0, 0),
                    Phone = "1234567890",
                    Email = "nguyendz@example.com" }
            );

        modelBuilder.Entity<Class>().HasData(
            new Class { ClassId = 1, ClassCode = "CS101" }
        );

        modelBuilder.Entity<Instructor>().HasData(
            new Instructor { InstructorId = 1,
                InstructorName = "Jane Smith",
                DateOfBirth = new DateTime(1997, 1, 1, 0, 0, 0),
                Phone = "0987654321",
                Email = "janesmith@example.com" }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                StudentId = 1,
                StudentCode = "S001",
                StudentInfoId = 1,
                ClassId = 1, }
            );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
