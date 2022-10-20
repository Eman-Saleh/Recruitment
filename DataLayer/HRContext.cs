using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Recruitment.DataLayer
{
    public partial class HRContext : DbContext
    {
        public HRContext()
        {
        }

        public HRContext(DbContextOptions<HRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateCv> CandidateCvs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<VacancyDescription> VacancyDescriptions { get; set; }
        public virtual DbSet<VacancyQualification> VacancyQualifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=EMAN-SALEH\\MSSQLSERVER17;Initial Catalog=HR;user id=sa;password=123;;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateCv>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Candidate_CV");

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CurrentCompany).HasMaxLength(10);

                entity.Property(e => e.Cv)
                    .HasMaxLength(100)
                    .HasColumnName("CV");

                entity.Property(e => e.Email).HasMaxLength(25);

                entity.Property(e => e.ExperienceId).HasColumnName("ExperienceID");

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");

                entity.Property(e => e.Mobile).HasMaxLength(11);

                entity.Property(e => e.NationalId4digits)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("NationalId_4digits");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.YearsOfExperience)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.ToTable("Job_Title");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.JobTitles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Title_Category");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Range)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.ToTable("Vacancy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.JobTitleId).HasColumnName("JobTitleID");

                entity.Property(e => e.PublishingDate).HasColumnType("date");

                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.YearsOfExperienceId).HasColumnName("YearsOfExperienceID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacancy_Category");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacancy_Country");

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacancy_Gender");

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.JobTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacancy_Job_Title");

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.SalaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacancy_Salary");

                entity.HasOne(d => d.YearsOfExperience)
                    .WithMany(p => p.Vacancies)
                    .HasForeignKey(d => d.YearsOfExperienceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacancy_Experience");
            });

            modelBuilder.Entity<VacancyDescription>(entity =>
            {
                entity.ToTable("Vacancy_Description");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.VacancyId).HasColumnName("VacancyID");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.VacancyDescriptions)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacancy_Description_Vacancy");
            });

            modelBuilder.Entity<VacancyQualification>(entity =>
            {
                entity.ToTable("Vacancy_Qualification");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Qualification).IsRequired();

                entity.Property(e => e.VacancyId).HasColumnName("VacancyID");

                entity.HasOne(d => d.Vacancy)
                    .WithMany(p => p.VacancyQualifications)
                    .HasForeignKey(d => d.VacancyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacancy_Qualification_Vacancy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
