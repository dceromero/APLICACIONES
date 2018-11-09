
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DataEntitysAplicaciones.DataEntitysDescuentos;

namespace DataAccessAplicaciones.DataAccessDescuentos
{

    public partial class ModelAplicacionesDescuentos : DbContext
    {
        public ModelAplicacionesDescuentos()
            : base("name=ModelDescuentos")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<CANALES> CANALES { get; set; }
        public virtual DbSet<CARGOS> CARGOS { get; set; }
        public virtual DbSet<CENCOS> CENCOS { get; set; }
        public virtual DbSet<CLIENTES_GENERAL> CLIENTES_GENERAL { get; set; }
        public virtual DbSet<CLIENTES_SECTOR> CLIENTES_SECTOR { get; set; }
        public virtual DbSet<EMPRESAS> EMPRESAS { get; set; }
        public virtual DbSet<ERRORES> ERRORES { get; set; }
        public virtual DbSet<HISTORICOPRECIOS> HISTORICOPRECIOS { get; set; }
        public virtual DbSet<JEFATURAS> JEFATURAS { get; set; }
        public virtual DbSet<MCDESCUENTOS> MCDESCUENTOS { get; set; }
        public virtual DbSet<MDDESCUENTO> MDDESCUENTO { get; set; }
        public virtual DbSet<MENU> MENU { get; set; }
        public virtual DbSet<OFICVENTAS> OFICVENTAS { get; set; }
        public virtual DbSet<PERMISOS> PERMISOS { get; set; }
        public virtual DbSet<PRECIOS> PRECIOS { get; set; }
        public virtual DbSet<PRODUCTOS> PRODUCTOS { get; set; }
        public virtual DbSet<REGIONALES> REGIONALES { get; set; }
        public virtual DbSet<ROLES> ROLES { get; set; }
        public virtual DbSet<SUBMENU> SUBMENU { get; set; }
        public virtual DbSet<TIPOSOLICITUD> TIPOSOLICITUD { get; set; }
        public virtual DbSet<UNIDADESMEDIDAS> UNIDADESMEDIDAS { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
        public virtual DbSet<VENDEDORES> VENDEDORES { get; set; }
        public virtual DbSet<VIEW_Jefes> VIEW_Jefes { get; set; }
        public virtual DbSet<VIEW_Permisos> VIEW_Permisos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CANALES>()
                .HasMany(e => e.CLIENTES_SECTOR)
                .WithRequired(e => e.CANALES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CANALES>()
                .HasMany(e => e.PRECIOS)
                .WithRequired(e => e.CANALES)
                .WillCascadeOnDelete(false);

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

            modelBuilder.Entity<CLIENTES_GENERAL>()
                .Property(e => e.GRUPO_CUENTAS)
                .IsFixedLength();

            modelBuilder.Entity<CLIENTES_GENERAL>()
                .Property(e => e.CODCONPAGO)
                .IsFixedLength();

            modelBuilder.Entity<CLIENTES_GENERAL>()
                .Property(e => e.GRPCLIENTE)
                .IsFixedLength();

            modelBuilder.Entity<CLIENTES_GENERAL>()
                .HasMany(e => e.MCDESCUENTOS)
                .WithRequired(e => e.CLIENTES_GENERAL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTES_SECTOR>()
                .Property(e => e.CODORGANIZACION)
                .IsFixedLength();

            modelBuilder.Entity<CLIENTES_SECTOR>()
                .Property(e => e.CODSECTOR)
                .IsFixedLength();

            modelBuilder.Entity<CLIENTES_SECTOR>()
                .Property(e => e.CODOFICINA)
                .IsFixedLength();

            modelBuilder.Entity<CLIENTES_SECTOR>()
                .Property(e => e.COD_VENDEDOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTES_SECTOR>()
                .Property(e => e.ZONAVENTAS)
                .IsFixedLength();

            modelBuilder.Entity<CLIENTES_SECTOR>()
                .Property(e => e.GRUPOCLI)
                .IsFixedLength();

            modelBuilder.Entity<EMPRESAS>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.EMPRESAS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MCDESCUENTOS>()
                .HasMany(e => e.MDDESCUENTO)
                .WithRequired(e => e.MCDESCUENTOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OFICVENTAS>()
                .Property(e => e.ID_OFICVENTA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<OFICVENTAS>()
                .HasMany(e => e.VENDEDORES)
                .WithRequired(e => e.OFICVENTAS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRECIOS>()
                .Property(e => e.CODCONPAGO)
                .IsFixedLength();

            modelBuilder.Entity<PRECIOS>()
                .Property(e => e.CODORGANIZACION)
                .IsFixedLength();

            modelBuilder.Entity<PRECIOS>()
                .Property(e => e.OFICINA)
                .IsFixedLength();

            modelBuilder.Entity<PRECIOS>()
                .Property(e => e.GRUPOCLI)
                .IsFixedLength();

            modelBuilder.Entity<PRECIOS>()
                .Property(e => e.CODUNIMEDIDA)
                .IsFixedLength();

            modelBuilder.Entity<PRECIOS>()
                .HasMany(e => e.HISTORICOPRECIOS)
                .WithRequired(e => e.PRECIOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.CODLINPRODUCTO)
                .IsFixedLength();

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.FIGBONIFICACION)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.GRMATERIALES)
                .IsFixedLength();

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.CODUNIMEDIDA)
                .IsFixedLength();

            modelBuilder.Entity<PRODUCTOS>()
                .HasMany(e => e.MDDESCUENTO)
                .WithRequired(e => e.PRODUCTOS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTOS>()
                .HasMany(e => e.PRECIOS)
                .WithRequired(e => e.PRODUCTOS)
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

            modelBuilder.Entity<TIPOSOLICITUD>()
                .HasMany(e => e.MCDESCUENTOS)
                .WithRequired(e => e.TIPOSOLICITUD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UNIDADESMEDIDAS>()
                .Property(e => e.CODUNIMEDIDA)
                .IsFixedLength();

            modelBuilder.Entity<UNIDADESMEDIDAS>()
                .HasMany(e => e.PRECIOS)
                .WithRequired(e => e.UNIDADESMEDIDAS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UNIDADESMEDIDAS>()
                .HasMany(e => e.PRODUCTOS)
                .WithRequired(e => e.UNIDADESMEDIDAS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.COD_VENDEDOR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .HasMany(e => e.JEFATURAS)
                .WithOptional(e => e.USUARIOS)
                .HasForeignKey(e => e.CODEMPLEADO);

            modelBuilder.Entity<USUARIOS>()
                .HasMany(e => e.JEFATURAS1)
                .WithOptional(e => e.USUARIOS1)
                .HasForeignKey(e => e.CODJEFATURA);

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
                .HasMany(e => e.CLIENTES_SECTOR)
                .WithRequired(e => e.VENDEDORES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VENDEDORES>()
                .HasMany(e => e.USUARIOS)
                .WithRequired(e => e.VENDEDORES)
                .WillCascadeOnDelete(false);
        }
    }
}
