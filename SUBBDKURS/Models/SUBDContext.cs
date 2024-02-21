using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBMS.Models
{
    public partial class SUBDContext : DbContext
    {
        public SUBDContext()
        {
        }

        public SUBDContext(DbContextOptions<SUBDContext> options) : base(options)
        {
        }

        public virtual DbSet<Budgets> Budgets { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Finproducts> Finproducts { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<PurchaseOfrawmaterials> PurchaseOfrawmaterials { get; set; }
        public virtual DbSet<Rawmaterials> Rawmaterials { get; set; }
        public virtual DbSet<Saleofproducts> Saleofproducts { get; set; }
        public virtual DbSet<Units> Units { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-KNA89UR\\SQLEXPRESS;Database=SUBD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budgets>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Budgetamount).HasColumnType("money");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("FK_Employees_Positions");
            });

            modelBuilder.Entity<Finproducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Finproducts)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Finproducts_Units");
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Ingredients_Finproducts");

                entity.HasOne(d => d.RawMaterialsNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.RawMaterials)
                    .HasConstraintName("FK_Ingredients_Rawmaterials");
            });

            modelBuilder.Entity<Months>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MonthName).HasMaxLength(50);
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Position).HasMaxLength(50);
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Production_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Production)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Production_Finproducts");
            });

            modelBuilder.Entity<PurchaseOfrawmaterials>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.PurchaseOfrawmaterials)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_PurchaseOfrawmaterials_Employees");

                entity.HasOne(d => d.RawMaterialsNavigation)
                    .WithMany(p => p.PurchaseOfrawmaterials)
                    .HasForeignKey(d => d.RawMaterials)
                    .HasConstraintName("FK_PurchaseOfrawmaterials_Rawmaterials");
            });

            modelBuilder.Entity<Rawmaterials>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Rawmaterials)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Rawmaterials_Units");
            });



            modelBuilder.Entity<Saleofproducts>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.Saleofproducts)
                    .HasForeignKey(d => d.Employee)
                    .HasConstraintName("FK_Saleofproducts_Employees");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.Saleofproducts)
                    .HasForeignKey(d => d.Product)
                    .HasConstraintName("FK_Saleofproducts_Finproducts");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
