using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace disaster_management.Models
{
    public partial class DaDManagementContext : DbContext
    {
        public DaDManagementContext()
        {
        }

        public DaDManagementContext(DbContextOptions<DaDManagementContext> options)
            : base(options)
        {
        }
        public DbSet<UserMembership> UserMemberships { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<DisasterPoint> DisasterPoints { get; set; } = null!;
        public virtual DbSet<DiseaseType> DiseaseTypes { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<FileAttachment> FileAttachments { get; set; } = null!;
        public virtual DbSet<LivestockFarm> LivestockFarms { get; set; } = null!;
        public virtual DbSet<LivestockFarmCondition> LivestockFarmConditions { get; set; } = null!;
        public virtual DbSet<LivestockStatistic> LivestockStatistics { get; set; } = null!;
        public virtual DbSet<Outbreak> Outbreaks { get; set; } = null!;
        public virtual DbSet<OutbreakDiagnosis> OutbreakDiagnoses { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<SafeLivestockZone> SafeLivestockZones { get; set; } = null!;
        public virtual DbSet<Slaughterhouse> Slaughterhouses { get; set; } = null!;
        public virtual DbSet<Symptom> Symptoms { get; set; } = null!;
        public virtual DbSet<TemporaryZone> TemporaryZones { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserGroup> UserGroups { get; set; } = null!;
        public virtual DbSet<UserLog> UserLogs { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<Vaccination> Vaccinations { get; set; } = null!;
        public virtual DbSet<VetMedicineAgency> VetMedicineAgencies { get; set; } = null!;
        public virtual DbSet<VeterinaryBranch> VeterinaryBranches { get; set; } = null!;
        public virtual DbSet<Ward> Wards { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JMJDD80\\SQLEXPRESS;Database=DaDManagement;User Id=sa;Password=Admin@1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Cấu hình UserId là khóa chính
            modelBuilder.Entity<UserMembership>()
             .HasKey(e => new { e.UserId, e.GroupId });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.CertificateId).HasColumnName("CertificateID");

                entity.Property(e => e.CertificateName).HasMaxLength(100);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("FK__Certifica__FarmI__0E6E26BF");
            });

            modelBuilder.Entity<DisasterPoint>(entity =>
            {
                entity.HasKey(e => e.DisasterId)
                    .HasName("PK__Disaster__B48777EEEF50FB03");

                entity.ToTable("DisasterPoint");

                entity.Property(e => e.DisasterId).HasColumnName("DisasterID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DisasterType).HasMaxLength(50);

                entity.Property(e => e.LocationName).HasMaxLength(100);

                entity.Property(e => e.OccurredTime).HasColumnType("datetime");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.Severity).HasMaxLength(50);

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.DisasterPoints)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK__DisasterP__Repor__18EBB532");
            });

            modelBuilder.Entity<DiseaseType>(entity =>
            {
                entity.HasKey(e => e.DiseaseId)
                    .HasName("PK__DiseaseT__69B533A9FDD6B732");

                entity.ToTable("DiseaseType");

                entity.Property(e => e.DiseaseId).HasColumnName("DiseaseID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.DiseaseGroup).HasMaxLength(100);

                entity.Property(e => e.DiseaseName).HasMaxLength(100);

                entity.Property(e => e.Severity).HasMaxLength(50);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.DistrictName).HasMaxLength(100);

                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId)
                    .HasConstraintName("FK__Districts__Provi__4BAC3F29");
            });

            modelBuilder.Entity<FileAttachment>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__FileAtta__6F0F989F1A8D7FFD");

                entity.ToTable("FileAttachment");

                entity.Property(e => e.FileId).HasColumnName("FileID");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.FilePath).HasMaxLength(200);

                entity.Property(e => e.FileType).HasMaxLength(50);

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.FileAttachments)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK__FileAttac__Repor__1BC821DD");
            });

            modelBuilder.Entity<LivestockFarm>(entity =>
            {
                entity.HasKey(e => e.FarmId)
                    .HasName("PK__Livestoc__ED7BBA999CF3FAA0");

                entity.ToTable("LivestockFarm");

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.FarmName).HasMaxLength(100);

                entity.Property(e => e.OwnerName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<LivestockFarmCondition>(entity =>
            {
                entity.HasKey(e => e.ConditionId)
                    .HasName("PK__Livestoc__37F5C0EF37B9AD83");

                entity.ToTable("LivestockFarmCondition");

                entity.Property(e => e.ConditionId).HasColumnName("ConditionID");

                entity.Property(e => e.ConditionDetail).HasMaxLength(500);

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.LivestockFarmConditions)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("FK__Livestock__FarmI__0B91BA14");
            });

            modelBuilder.Entity<LivestockStatistic>(entity =>
            {
                entity.HasKey(e => e.StatisticId)
                    .HasName("PK__Livestoc__367DEB379972D3C6");

                entity.ToTable("LivestockStatistic");

                entity.Property(e => e.StatisticId).HasColumnName("StatisticID");

                entity.Property(e => e.AnimalType).HasMaxLength(50);

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.StatisticDate).HasColumnType("datetime");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.LivestockStatistics)
                    .HasForeignKey(d => d.FarmId)
                    .HasConstraintName("FK__Livestock__FarmI__114A936A");
            });

            modelBuilder.Entity<Outbreak>(entity =>
            {
                entity.ToTable("Outbreak");

                entity.Property(e => e.OutbreakId).HasColumnName("OutbreakID");

                entity.Property(e => e.DetectedDate).HasColumnType("datetime");

                entity.Property(e => e.DiseaseId).HasColumnName("DiseaseID");

                entity.Property(e => e.OutbreakName).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Disease)
                    .WithMany(p => p.Outbreaks)
                    .HasForeignKey(d => d.DiseaseId)
                    .HasConstraintName("FK__Outbreak__Diseas__75A278F5");

                entity.HasMany(d => d.Symptoms)
                    .WithMany(p => p.Outbreaks)
                    .UsingEntity<Dictionary<string, object>>(
                        "OutbreakSymptom",
                        l => l.HasOne<Symptom>().WithMany().HasForeignKey("SymptomId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__OutbreakS__Sympt__7F2BE32F"),
                        r => r.HasOne<Outbreak>().WithMany().HasForeignKey("OutbreakId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__OutbreakS__Outbr__7E37BEF6"),
                        j =>
                        {
                            j.HasKey("OutbreakId", "SymptomId").HasName("PK__Outbreak__C5CC6E16A8498305");

                            j.ToTable("OutbreakSymptom");

                            j.IndexerProperty<int>("OutbreakId").HasColumnName("OutbreakID");

                            j.IndexerProperty<int>("SymptomId").HasColumnName("SymptomID");
                        });
            });

            modelBuilder.Entity<OutbreakDiagnosis>(entity =>
            {
                entity.HasKey(e => e.DiagnosisId)
                    .HasName("PK__Outbreak__0C54CB93F2634F3E");

                entity.ToTable("OutbreakDiagnosis");

                entity.Property(e => e.DiagnosisId).HasColumnName("DiagnosisID");

                entity.Property(e => e.DiagnosisDate).HasColumnType("datetime");

                entity.Property(e => e.DiagnosisResult).HasMaxLength(500);

                entity.Property(e => e.DoctorName).HasMaxLength(100);

                entity.Property(e => e.OutbreakId).HasColumnName("OutbreakID");

                entity.HasOne(d => d.Outbreak)
                    .WithMany(p => p.OutbreakDiagnoses)
                    .HasForeignKey(d => d.OutbreakId)
                    .HasConstraintName("FK__OutbreakD__Outbr__787EE5A0");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.ProvinceId).HasColumnName("ProvinceID");

                entity.Property(e => e.ProvinceName).HasMaxLength(100);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReportName).HasMaxLength(100);

                entity.Property(e => e.Summary).HasMaxLength(500);
            });

            modelBuilder.Entity<SafeLivestockZone>(entity =>
            {
                entity.HasKey(e => e.ZoneId)
                    .HasName("PK__SafeLive__6016679516F848EA");

                entity.ToTable("SafeLivestockZone");

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.ZoneName).HasMaxLength(100);
            });

            modelBuilder.Entity<Slaughterhouse>(entity =>
            {
                entity.ToTable("Slaughterhouse");

                entity.Property(e => e.SlaughterhouseId).HasColumnName("SlaughterhouseID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.SlaughterhouseName).HasMaxLength(100);
            });

            modelBuilder.Entity<Symptom>(entity =>
            {
                entity.ToTable("Symptom");

                entity.Property(e => e.SymptomId).HasColumnName("SymptomID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.SymptomName).HasMaxLength(100);
            });

            modelBuilder.Entity<TemporaryZone>(entity =>
            {
                entity.HasKey(e => e.ZoneId)
                    .HasName("PK__Temporar__601667958F6BF5FE");

                entity.ToTable("TemporaryZone");

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.ZoneName).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasMany(d => d.Groups)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserGroupMembership",
                        l => l.HasOne<UserGroup>().WithMany().HasForeignKey("GroupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserGroup__Group__6754599E"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserGroup__UserI__66603565"),
                        j =>
                        {
                            j.HasKey("UserId", "GroupId").HasName("PK__UserGrou__A6C1639C4A7A6328");

                            j.ToTable("UserGroupMembership");

                            j.IndexerProperty<int>("UserId").HasColumnName("UserID");

                            j.IndexerProperty<int>("GroupId").HasColumnName("GroupID");
                        });
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__UserGrou__149AF30A4191BBE1");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.GroupName).HasMaxLength(100);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Groups)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserGroupRole",
                        l => l.HasOne<UserRole>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserGroup__RoleI__6383C8BA"),
                        r => r.HasOne<UserGroup>().WithMany().HasForeignKey("GroupId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserGroup__Group__628FA481"),
                        j =>
                        {
                            j.HasKey("GroupId", "RoleId").HasName("PK__UserGrou__AC355FE9CC169D6A");

                            j.ToTable("UserGroupRoles");

                            j.IndexerProperty<int>("GroupId").HasColumnName("GroupID");

                            j.IndexerProperty<int>("RoleId").HasColumnName("RoleID");
                        });
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__UserLogs__5E5499A81A201FF8");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.ActionDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceInfo).HasMaxLength(255);

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(50)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserLogs__UserID__6B24EA82");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__UserRole__8AFACE3A9F3D064B");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.RoleName).HasMaxLength(100);
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.ToTable("Vaccination");

                entity.Property(e => e.VaccinationId).HasColumnName("VaccinationID");

                entity.Property(e => e.OutbreakId).HasColumnName("OutbreakID");

                entity.Property(e => e.VaccinationDate).HasColumnType("datetime");

                entity.Property(e => e.VaccineName).HasMaxLength(100);

                entity.HasOne(d => d.Outbreak)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.OutbreakId)
                    .HasConstraintName("FK__Vaccinati__Outbr__7B5B524B");
            });

            modelBuilder.Entity<VetMedicineAgency>(entity =>
            {
                entity.HasKey(e => e.AgencyId)
                    .HasName("PK__VetMedic__95C546FBEE90A99B");

                entity.ToTable("VetMedicineAgency");

                entity.Property(e => e.AgencyId).HasColumnName("AgencyID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AgencyName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<VeterinaryBranch>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK__Veterina__A1682FA5B415CAC5");

                entity.ToTable("VeterinaryBranch");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BranchName).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.Property(e => e.WardId).HasColumnName("WardID");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.WardName).HasMaxLength(100);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__Wards__DistrictI__4E88ABD4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
