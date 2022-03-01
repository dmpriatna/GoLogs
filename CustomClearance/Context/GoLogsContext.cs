using System.Linq;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CustomClearance.Context
{
    public partial class GoLogsContext : DbContext
    {
        public GoLogsContext(DbContextOptions<GoLogsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CustomClearanceEntity> CustomClearanceSet { get; set; }
        public virtual DbSet<CustomClearanceFileEntity> CustomClearanceFileSet { get; set; }
        public virtual DbSet<CustomClearanceItemEntity> CustomClearanceItemSet { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }

    public string JobNumber
    {
      get
      {
        int one = 1;
        string suffix = one.ToString("D6");
        string result = null;

        var now = System.DateTime.Now;
        var patern = System.DateTime.Now.ToString("yyyy-MM/CC/GOLOGS/dd-");

        var lastCode = CustomClearanceSet
          .Where(w => w.CreatedDate.Date == now.Date)
          .OrderBy(ob => ob.CreatedDate)
          .LastOrDefault();

        if (lastCode == null)
          result = patern + suffix;
        else
        {
          if (string.IsNullOrWhiteSpace(lastCode.JobNumber))
            result = patern + suffix;
          else
          {
            var chunk = lastCode.JobNumber.Split('-').Last();
            if (int.TryParse(chunk, out int code))
            {
              code++;
              result = patern + code.ToString("D6");
            }
            else
              result = patern + now.ToString("HHmmss");
          }
        }
        return result;
      }
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nib).HasColumnName("NIB");

                entity.Property(e => e.Npwp).HasColumnName("NPWP");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");
            });

            modelBuilder.Entity<CustomClearanceEntity>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.BlDate).HasMaxLength(16);

                entity.Property(e => e.BlNumber).HasMaxLength(32);

                entity.Property(e => e.CargoOwnerName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.CargoOwnerNpwp)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CustomsOfficeName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.DocumentTypeName)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.ImportTypeName)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.NotifyEmail).IsRequired();

                entity.Property(e => e.PaymentMethodName)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Phone).HasMaxLength(16);

                entity.Property(e => e.PibTypeName)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.PpjkName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.PpjkNpwp)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.RequestDate).HasMaxLength(16);

                entity.Property(e => e.RowStatus).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<CustomClearanceFileEntity>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.RowStatus).HasDefaultValueSql("1");

                entity.Property(e => e.CustomClearanceId)
                    .IsRequired();

                entity.Property(e => e.DocumentType)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.FileName)
                    .IsRequired();
            });

            modelBuilder.Entity<CustomClearanceItemEntity>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ModifiedBy).HasMaxLength(36);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.RowStatus).HasDefaultValueSql("1");

                entity.Property(e => e.CustomClearanceId)
                    .IsRequired();

                entity.Property(e => e.HsCode)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.ItemName)
                    .IsRequired();

                entity.Property(e => e.HsCode)
                    .IsRequired();
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasMaxLength(128);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.ModifiedBy).HasMaxLength(128);

                entity.Property(e => e.Npwp)
                    .IsRequired()
                    .HasColumnName("NPWP")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasDefaultValueSql("''::character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
