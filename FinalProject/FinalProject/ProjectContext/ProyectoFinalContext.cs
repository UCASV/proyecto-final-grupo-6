using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinalProject.ProjectContext
{
    public partial class ProyectoFinalContext : DbContext
    {
        public ProyectoFinalContext()
        {
        }

        public ProyectoFinalContext(DbContextOptions<ProyectoFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<ProcessVaccination> ProcessVaccinations { get; set; }
        public virtual DbSet<Processxcitizen> Processxcitizens { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;DataBase=ProyectoFinal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("APPOINTMENT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.DuiCitizen)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("dui_citizen");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdPlace).HasColumnName("id_place");

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DuiCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__dui_c__44FF419A");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_em__440B1D61");

                entity.HasOne(d => d.IdPlaceNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdPlace)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__APPOINTME__id_pl__47DBAE45");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.ToTable("CABIN");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PK__CITIZEN__D876F1BE85F71030");

                entity.ToTable("CITIZEN");

                entity.Property(e => e.Dui)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("dui");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email")
                    .HasDefaultValueSql("('No posee correo electrónico')");

                entity.Property(e => e.IdGroup).HasColumnName("id_group");

                entity.Property(e => e.IdInstitution).HasColumnName("id_institution");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_grou__46E78A0C");

                entity.HasOne(d => d.IdInstitutionNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdInstitution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CITIZEN__id_inst__45F365D3");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLOYEE__id_cab__412EB0B6");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPLOYEE__id_typ__48CFD27E");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("GROUP");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Group1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("group");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.ToTable("INSTITUTION");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Institution1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("institution");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.ToTable("PLACE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Place1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("place");
            });

            modelBuilder.Entity<ProcessVaccination>(entity =>
            {
                entity.ToTable("PROCESS_VACCINATION");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatetimeEffect)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime_effect");

                entity.Property(e => e.DatetimeInitiation)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime_initiation");

                entity.Property(e => e.DatetimeRegistered)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime_registered");

                entity.Property(e => e.DatetimeVaccine)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime_vaccine");

                entity.Property(e => e.IdAppointment).HasColumnName("id_appointment");

                entity.HasOne(d => d.IdAppointmentNavigation)
                    .WithMany(p => p.ProcessVaccinations)
                    .HasForeignKey(d => d.IdAppointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROCESS_V__id_ap__49C3F6B7");
            });

            modelBuilder.Entity<Processxcitizen>(entity =>
            {
                entity.HasKey(e => new { e.IdCitizen, e.IdProcess });

                entity.ToTable("PROCESSXCITIZEN");

                entity.Property(e => e.IdCitizen)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("id_citizen");

                entity.Property(e => e.IdProcess).HasColumnName("id_process");

                entity.HasOne(d => d.IdCitizenNavigation)
                    .WithMany(p => p.Processxcitizens)
                    .HasForeignKey(d => d.IdCitizen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROCESSXC__id_ci__4AB81AF0");

                entity.HasOne(d => d.IdProcessNavigation)
                    .WithMany(p => p.Processxcitizens)
                    .HasForeignKey(d => d.IdProcess)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PROCESSXC__id_pr__4BAC3F29");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("SESSION");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datetime)
                    .HasColumnType("datetime")
                    .HasColumnName("datetime");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.IdCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SESSION__id_cabi__4316F928");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SESSION__id_empl__4222D4EF");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("TYPE");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
