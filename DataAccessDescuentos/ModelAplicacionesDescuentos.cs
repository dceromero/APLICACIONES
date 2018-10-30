namespace DataAccessAplicaciones.DataAccessDescuentos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
   using DataEntitysAplicaciones.DataEntitysDescuentos;
    public partial class ModelAplicacionesDescuentos : DbContext
    {
        public ModelAplicacionesDescuentos()
            : base("name=ModelAplicacionesDescuentos")
        {
        }

        public virtual DbSet<CANALES> CANALES { get; set; }
        public virtual DbSet<CARGOS> CARGOS { get; set; }
        public virtual DbSet<CENCOS> CENCOS { get; set; }
        public virtual DbSet<EMPRESAS> EMPRESAS { get; set; }
        public virtual DbSet<ERRORES> ERRORES { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }
        public virtual DbSet<OFICVENTAS> OFICVENTAS { get; set; }
        public virtual DbSet<PERMISOS> PERMISOS { get; set; }
        public virtual DbSet<REGIONALES> REGIONALES { get; set; }
        public virtual DbSet<ROLES> ROLES { get; set; }
        public virtual DbSet<SUBMENU> SUBMENU { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
        public virtual DbSet<VENDEDORES> VENDEDORES { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CANALES>()
                .HasMany(e => e.VENDEDORES)
                .WithRequired(e => e.CANALES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CARGOS>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.CARGOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CENCOS>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.CENCOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPRESAS>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.EMPRESAS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OFICVENTAS>()
                .Property(e => e.ID_OFICVENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OFICVENTAS>()
                .HasMany(e => e.VENDEDORES)
                .WithRequired(e => e.OFICVENTAS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGIONALES>()
                .Property(e => e.ID_REGIONAL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<REGIONALES>()
                .HasMany(e => e.VENDEDORES)
                .WithRequired(e => e.REGIONALES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROLES>()
                .HasMany(e => e.PERMISOS)
                .WithRequired(e => e.ROLES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROLES>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.ROLES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBMENU>()
                .HasMany(e => e.PERMISOS)
                .WithRequired(e => e.SUBMENU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.COD_VENDEDOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VENDEDORES>()
                .Property(e => e.COD_VENDEDOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VENDEDORES>()
                .Property(e => e.ID_REGIONAL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VENDEDORES>()
                .Property(e => e.ID_OFICVENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<VENDEDORES>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.VENDEDORES)
                .WillCascadeOnDelete(false);
        }
    }
}
