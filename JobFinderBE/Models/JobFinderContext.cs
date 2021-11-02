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

        public virtual DbSet<Company> Companies { get; set; }
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

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AboutCompany).HasColumnName("aboutCompany");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Logo)
                    .IsUnicode(false)
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

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
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("1stInjectionDate");

                entity.Property(e => e._2stInjectionDate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
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

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyId).HasColumnName("companyID");

                entity.Property(e => e.CovidPassport)
                    .HasMaxLength(255)
                    .HasColumnName("covidPassport");

                entity.Property(e => e.Employee)
                    .HasMaxLength(50)
                    .HasColumnName("employee");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.JobName)
                    .HasMaxLength(255)
                    .HasColumnName("jobName");

                entity.Property(e => e.JobOpportunity)
                    .HasMaxLength(255)
                    .HasColumnName("jobOpportunity");

                entity.Property(e => e.JobResponsbilities).HasColumnName("jobResponsbilities");

                entity.Property(e => e.MainCriteria)
                    .HasMaxLength(255)
                    .HasColumnName("mainCriteria");

                entity.Property(e => e.SalaryDescription)
                    .HasMaxLength(255)
                    .HasColumnName("salaryDescription");

                entity.Property(e => e.SalaryDetail)
                    .HasMaxLength(255)
                    .HasColumnName("salaryDetail");

                entity.Property(e => e.Sallary)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sallary");

                entity.Property(e => e.Tag)
                    .HasMaxLength(255)
                    .HasColumnName("tag");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.WorkingPlace)
                    .HasMaxLength(255)
                    .HasColumnName("workingPlace");

                entity.Property(e => e.WorkingTime)
                    .HasMaxLength(255)
                    .HasColumnName("workingTime");

                entity.Property(e => e.WorkingTimeDescription)
                    .HasMaxLength(255)
                    .HasColumnName("workingTimeDescription");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Job_Company");
            });

            modelBuilder.Entity<JobSeekerEducation>(entity =>
            {
                entity.ToTable("JobSeekerEducation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Education)
                    .HasMaxLength(255)
                    .HasColumnName("education");

                entity.Property(e => e.EndDay)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endDay");

                entity.Property(e => e.IsStillStudying).HasColumnName("isStillStudying");

                entity.Property(e => e.Majors)
                    .HasMaxLength(255)
                    .HasColumnName("majors");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(255)
                    .HasColumnName("schoolName");

                entity.Property(e => e.StartDay)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("startDay");

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

                entity.Property(e => e.Company)
                    .HasMaxLength(255)
                    .HasColumnName("company");

                entity.Property(e => e.EndDay)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("endDay");

                entity.Property(e => e.Experience)
                    .HasMaxLength(50)
                    .HasColumnName("experience");

                entity.Property(e => e.IsStillWorking).HasColumnName("isStillWorking");

                entity.Property(e => e.Job)
                    .HasMaxLength(255)
                    .HasColumnName("job");

                entity.Property(e => e.Skill)
                    .HasMaxLength(50)
                    .HasColumnName("skill");

                entity.Property(e => e.StartDay)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("startDay");

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
                entity.ToTable("UserJob");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("date");

                entity.Property(e => e.JobId).HasColumnName("jobID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.UserJobs)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_UserJob_Job");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserJobs)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Job_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
