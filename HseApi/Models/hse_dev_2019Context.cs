using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HseApi.Models
{
    public partial class hse_dev_2019Context : DbContext
    {
        public hse_dev_2019Context()
        {
        }

        public hse_dev_2019Context(DbContextOptions<hse_dev_2019Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Access> Access { get; set; }
        public virtual DbSet<CmsContactForm> CmsContactForm { get; set; }
        public virtual DbSet<CmsDocument> CmsDocument { get; set; }
        public virtual DbSet<CoreAccess> CoreAccess { get; set; }
        public virtual DbSet<CoreCategory> CoreCategory { get; set; }
        public virtual DbSet<CoreFileAuditUpload> CoreFileAuditUpload { get; set; }
        public virtual DbSet<CoreFileUpload> CoreFileUpload { get; set; }
        public virtual DbSet<CoreOption> CoreOption { get; set; }
        public virtual DbSet<CoreUser> CoreUser { get; set; }
        public virtual DbSet<FailedLogin> FailedLogin { get; set; }
        public virtual DbSet<FileUpload> FileUpload { get; set; }
        public virtual DbSet<HseAudit> HseAudit { get; set; }
        public virtual DbSet<HseInvestigationReport> HseInvestigationReport { get; set; }
        public virtual DbSet<HseQr> HseQr { get; set; }
        public virtual DbSet<HseQuarterlyReport> HseQuarterlyReport { get; set; }
        public virtual DbSet<HseRisk> HseRisk { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<RememberToken> RememberToken { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SuccessLogin> SuccessLogin { get; set; }
        public virtual DbSet<Translation> Translation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=117.6.162.49;Database=hse_dev_2019;Username=postgres;Password=GppmDev@0!9");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("access");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .HasColumnName("action")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.Object)
                    .HasColumnName("object")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.RoleUuid).HasColumnName("role_uuid");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("character varying(50)");
            });

            modelBuilder.Entity<CmsContactForm>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("cms_contact_form");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<CmsDocument>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("cms_document");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<CoreAccess>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("core_access");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<CoreCategory>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("core_category");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<CoreFileAuditUpload>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("core_file_audit_upload");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.ModelUuid).HasColumnName("model_uuid");

                entity.Property(e => e.Module)
                    .HasColumnName("module")
                    .HasColumnType("character varying(30)");

                entity.Property(e => e.Problem)
                    .HasColumnName("problem")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<CoreFileUpload>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("core_file_upload");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.ModelUuid).HasColumnName("model_uuid");

                entity.Property(e => e.Module)
                    .HasColumnName("module")
                    .HasColumnType("character varying(30)");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<CoreOption>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("core_option");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<CoreUser>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("core_user");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Acl)
                    .HasColumnName("acl")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Activation)
                    .HasColumnName("activation")
                    .HasColumnType("character varying(15)")
                    .HasDefaultValueSql("'0'::character varying");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.LoggedIp)
                    .HasColumnName("logged_ip")
                    .HasColumnType("character varying(32)");

                entity.Property(e => e.LoggedOn).HasColumnName("logged_on");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.PasswordMobile)
                    .HasColumnName("password_mobile")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("character varying(100)");
            });

            modelBuilder.Entity<FailedLogin>(entity =>
            {
                entity.ToTable("failed_login");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Attempted).HasColumnName("attempted");

                entity.Property(e => e.IpAddress).HasColumnName("ip_address");

                entity.Property(e => e.UserUuid).HasColumnName("user_uuid");
            });

            modelBuilder.Entity<FileUpload>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("file_upload");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.ModelUuid).HasColumnName("model_uuid");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<HseAudit>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("hse_audit");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("jsonb");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.DataArr)
                    .HasColumnName("data_arr")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Kind).HasColumnName("kind");

                entity.Property(e => e.Quarter).HasColumnName("quarter");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<HseInvestigationReport>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("hse_investigation_report");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("jsonb");

                entity.Property(e => e.ClosedOn).HasColumnName("closed_on");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.DataArr)
                    .HasColumnName("data_arr")
                    .HasColumnType("jsonb");

                entity.Property(e => e.HappenedOn).HasColumnName("happened_on");

                entity.Property(e => e.Kind).HasColumnName("kind");

                entity.Property(e => e.Snapchart).HasColumnName("snapchart");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<HseQr>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("hse_qr");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("jsonb");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.DataArr)
                    .HasColumnName("data_arr")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Kind).HasColumnName("kind");

                entity.Property(e => e.Quarter).HasColumnName("quarter");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<HseQuarterlyReport>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("hse_quarterly_report");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("jsonb");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.DataArr)
                    .HasColumnName("data_arr")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Kind).HasColumnName("kind");

                entity.Property(e => e.Quarter).HasColumnName("quarter");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<HseRisk>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("hse_risk");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("jsonb");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.DataArr)
                    .HasColumnName("data_arr")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Kind).HasColumnName("kind");

                entity.Property(e => e.Quarter).HasColumnName("quarter");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("post");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("jsonb");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserUuid).HasColumnName("user_uuid");

                entity.Property(e => e.Workflow)
                    .HasColumnName("workflow")
                    .HasColumnType("jsonb");
            });

            modelBuilder.Entity<RememberToken>(entity =>
            {
                entity.ToTable("remember_token");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("character varying(32)");

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasColumnType("character varying(250)");

                entity.Property(e => e.UserUuid).HasColumnName("user_uuid");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("role");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying(50)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("character varying(50)");
            });

            modelBuilder.Entity<SuccessLogin>(entity =>
            {
                entity.ToTable("success_login");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IpAddress).HasColumnName("ip_address");

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasColumnType("character varying(250)");

                entity.Property(e => e.UserUuid).HasColumnName("user_uuid");
            });

            modelBuilder.Entity<Translation>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.ToTable("translation");

                entity.Property(e => e.Uuid)
                    .HasColumnName("uuid")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("character varying");

                entity.Property(e => e.Phone2)
                    .HasColumnName("phone2")
                    .HasColumnType("character varying(100)");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });
        }
    }
}
