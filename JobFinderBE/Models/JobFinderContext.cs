using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JobFinderBE.Models
{
    public partial class JobFinderContext : DbContext
    {
        public JobFinderContext()
        {
        }

        public JobFinderContext(DbContextOptions<JobFinderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CovidPassport> CovidPassports { get; set; }
        public virtual DbSet<CovidTestPaper> CovidTestPapers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobSeekerEducation> JobSeekerEducations { get; set; }
        public virtual DbSet<JobSeekerWorkExperience> JobSeekerWorkExperiences { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserJob> UserJobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=JobFinder;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CovidPassport>(entity =>
            {
                entity.ToTable("Covid_Passport");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.QrCode)
                    .IsUnicode(false)
                    .HasColumnName("qrCode");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e._1stInjectionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("1stInjectionDate");

                entity.Property(e => e._2stInjectionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("2stInjectionDate");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CovidPassports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Covid_Passport_User");
            });

            modelBuilder.Entity<CovidTestPaper>(entity =>
            {
                entity.ToTable("Covid_Test_Paper");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Image)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.TestResult).HasColumnName("testResult");

                entity.Property(e => e.TestType).HasColumnName("testType");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CovidTestPapers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Covid_Test_Paper_User");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Skill)
                    .HasMaxLength(50)
                    .HasColumnName("skill");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<JobSeekerEducation>(entity =>
            {
                entity.ToTable("JobSeekerEducation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Education)
                    .HasMaxLength(50)
                    .HasColumnName("education");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobSeekerEducations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_JobSeekerEducation_User");
            });

            modelBuilder.Entity<JobSeekerWorkExperience>(entity =>
            {
                entity.ToTable("JobSeekerWorkExperience");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.Skill)
                    .HasMaxLength(50)
                    .HasColumnName("skill");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobSeekerWorkExperiences)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acc_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CitizenIdentification).HasColumnName("citizenIdentification");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Education).HasColumnName("education");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .HasColumnName("fullname");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<UserJob>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserJob");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.JobId).HasColumnName("jobID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Job)
                    .WithMany()
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_UserJob_Job");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Job_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
