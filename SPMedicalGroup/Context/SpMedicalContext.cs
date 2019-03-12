using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPMedicalGroup.DomainsContextDir
{
    public partial class SpMedicalContext : DbContext
    {
        public SpMedicalContext()
        {
        }

        public SpMedicalContext(DbContextOptions<SpMedicalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consultas> Consultas { get; set; }
        public virtual DbSet<Especialidade> Especialidade { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Situacao> Situacao { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= SP_MEDICAL_GROUP;user id=sa; password= 132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.ToTable("CLINICA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioDeFuncionamento)
                    .HasColumnName("HORARIO_DE_FUNCIONAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasColumnName("RAZAO_SOCIAL")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Consultas>(entity =>
            {
                entity.ToTable("CONSULTAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataAgendamento)
                    .HasColumnName("DATA_AGENDAMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MedicosId).HasColumnName("MEDICOS_ID");

                entity.Property(e => e.PacienteId).HasColumnName("PACIENTE_ID");

                entity.Property(e => e.SituacaoId).HasColumnName("SITUACAO_ID");

                entity.HasOne(d => d.Medicos)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.MedicosId)
                    .HasConstraintName("FK__CONSULTAS__MEDIC__5FB337D6");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK__CONSULTAS__PACIE__5EBF139D");

                entity.HasOne(d => d.Situacao)
                    .WithMany(p => p.Consultas)
                    .HasForeignKey(d => d.SituacaoId)
                    .HasConstraintName("FK__CONSULTAS__SITUA__60A75C0F");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.ToTable("ESPECIALIDADE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.ToTable("MEDICOS");

                entity.HasIndex(e => e.Crm)
                    .HasName("UQ__MEDICOS__C1F887FF9E8100C4")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClinicaId).HasColumnName("CLINICA_ID");

                entity.Property(e => e.Crm).HasColumnName("CRM");

                entity.Property(e => e.EspecialidadeId).HasColumnName("ESPECIALIDADE_ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");

                entity.HasOne(d => d.Clinica)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.ClinicaId)
                    .HasConstraintName("FK__MEDICOS__CLINICA__5629CD9C");

                entity.HasOne(d => d.Especialidade)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.EspecialidadeId)
                    .HasConstraintName("FK__MEDICOS__ESPECIA__5535A963");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__MEDICOS__USUARIO__571DF1D5");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.ToTable("PACIENTES");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__PACIENTE__C1F89731506A217C")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__PACIENTE__321537C882635CC0")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.EMail)
                    .HasColumnName("E_MAIL")
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.Rg).HasColumnName("RG");

                entity.Property(e => e.Telefone)
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("USUARIO_ID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__PACIENTES__USUAR__5BE2A6F2");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.ToTable("SITUACAO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(110)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuarioId).HasColumnName("TIPO_USUARIO_ID");

                entity.HasOne(d => d.TipoUsuario)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .HasConstraintName("FK__USUARIOS__TIPO_U__5165187F");
            });
        }
    }
}
