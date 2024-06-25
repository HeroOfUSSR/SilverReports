using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SilverReports.Context
{
    public partial class SilverREContext : DbContext
    {
        public SilverREContext()
            : base("Server=sqlsrv; Database=SilverRE; User ID=user1; Password=user1")
        {
        }

        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<DecimalNumber> DecimalNumber { get; set; }
        public virtual DbSet<SilverType> SilverType { get; set; }
        public virtual DbSet<Norm> Norm { get; set; }
        public virtual DbSet<Department> Department { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Check>().ToTable("Check");
            modelBuilder.Entity<Check>().HasKey(x => x.ID_Check);
            modelBuilder.Entity<Check>().Property(x => x.Norm_Check).HasPrecision(20, 6);
            modelBuilder.Entity<Check>().Property(x => x.Coverage_Check).HasPrecision(10, 5);

            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Department>().HasKey(x => x.Code_Department);
            modelBuilder.Entity<Department>().HasMany(x => x.Norms)
                .WithRequired(c => c.Department_NormNavigation)
                .HasForeignKey(c => c.Department_Norm)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Department>().HasMany(x => x.Checks)
                .WithRequired(c => c.Department_CheckNavigation)
                .HasForeignKey(c => c.Department_Check)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DecimalNumber>().ToTable("DecimalNumber");
            modelBuilder.Entity<DecimalNumber>().HasKey(x => x.ID_Decimal);
            modelBuilder.Entity<DecimalNumber>().HasMany(x => x.Norms)
                .WithRequired(c => c.Decimal_NormNavigation)
                .HasForeignKey(c => c.Decimal_Norm) 
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<DecimalNumber>().HasMany(x => x.Checks)
                .WithRequired(c => c.Decimal_CheckNavigation)
                .HasForeignKey(c => c.Decimal_Check) 
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Norm>().ToTable("Norm");
            modelBuilder.Entity<Norm>().HasKey(x => x.ID_Norm);
            modelBuilder.Entity<Norm>().Property(x => x.Title_Norm).HasPrecision(20, 6);


            modelBuilder.Entity<SilverType>().ToTable("SilverType");
            modelBuilder.Entity<SilverType>().HasKey(x => x.Code_SilverType);
            modelBuilder.Entity<SilverType>().HasMany(x => x.Norms)
                .WithRequired(c => c.SilverType_NormNavigation)
                .HasForeignKey(c => c.SilverType_Norm)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<SilverType>().HasMany(x => x.Checks)
                .WithRequired(c => c.SilverType_CheckNavigation)
                .HasForeignKey(c => c.SilverType_Check)
                .WillCascadeOnDelete(false);
        }
    }
}
