using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mvctest.Models
{
    public partial class TestStudContext : DbContext
    {
        public virtual DbSet<Atsiskaitymas> Atsiskaitymas { get; set; }
        public virtual DbSet<Destytojas> Destytojas { get; set; }
        public virtual DbSet<Modulis> Modulis { get; set; }
        public virtual DbSet<Studentas> Studentas { get; set; }


        public TestStudContext(DbContextOptions<TestStudContext> options)
    : base(options)
{ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;Initial Catalog=TestStud;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atsiskaitymas>(entity =>
            {
                entity.HasKey(e => e.IdAtsiskaitymas);

                entity.Property(e => e.IdAtsiskaitymas)
                    .HasColumnName("id_Atsiskaitymas")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkStudentasidStudentas).HasColumnName("fk_Studentasid_Studentas");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pazymys).HasColumnName("pazymys");

                entity.HasOne(d => d.FkStudentasidStudentasNavigation)
                    .WithMany(p => p.Atsiskaitymas)
                    .HasForeignKey(d => d.FkStudentasidStudentas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("atsiskaito");
            });

            modelBuilder.Entity<Destytojas>(entity =>
            {
                entity.HasKey(e => e.IdDestytojas);

                entity.Property(e => e.IdDestytojas)
                    .HasColumnName("id_Destytojas")
                    .ValueGeneratedNever();

                entity.Property(e => e.Metai)
                    .HasColumnName("metai")
                    .HasColumnType("date");

                entity.Property(e => e.Pavarde)
                    .HasColumnName("pavarde")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vardas)
                    .HasColumnName("vardas")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Modulis>(entity =>
            {
                entity.HasKey(e => e.Kodas);

                entity.Property(e => e.Kodas)
                    .HasColumnName("kodas")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FkStudentasidStudentas).HasColumnName("fk_Studentasid_Studentas");

                entity.Property(e => e.FkStudentasidStudentas1).HasColumnName("fk_Studentasid_Studentas1");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkStudentasidStudentasNavigation)
                    .WithMany(p => p.ModulisFkStudentasidStudentasNavigation)
                    .HasForeignKey(d => d.FkStudentasidStudentas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi");

                entity.HasOne(d => d.FkStudentasidStudentas1Navigation)
                    .WithMany(p => p.ModulisFkStudentasidStudentas1Navigation)
                    .HasForeignKey(d => d.FkStudentasidStudentas1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Modulis__fk_Stud__2D27B809");
            });

            modelBuilder.Entity<Studentas>(entity =>
            {
                entity.HasKey(e => e.IdStudentas);

                entity.Property(e => e.IdStudentas)
                    .HasColumnName("id_Studentas")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkDestytojasidDestytojas).HasColumnName("fk_Destytojasid_Destytojas");

                entity.Property(e => e.Metai)
                    .HasColumnName("metai")
                    .HasColumnType("date");

                entity.Property(e => e.Pavarde)
                    .HasColumnName("pavarde")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Universitetas)
                    .HasColumnName("universitetas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vardas)
                    .HasColumnName("vardas")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkDestytojasidDestytojasNavigation)
                    .WithMany(p => p.Studentas)
                    .HasForeignKey(d => d.FkDestytojasidDestytojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("moko");
            });
        }
    }
}
