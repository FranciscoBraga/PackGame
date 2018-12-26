namespace ClassLibrary1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Etapa> Etapa { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Imagem> Imagem { get; set; }
        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Studio> Studio { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etapa>()
                .Property(e => e.etapaGame)
                .IsUnicode(false);

            modelBuilder.Entity<Genero>()
                .Property(e => e.generoGame)
                .IsUnicode(false);

            modelBuilder.Entity<Genero>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Imagem>()
                .Property(e => e.caminho)
                .IsUnicode(false);

            modelBuilder.Entity<Jogo>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Jogo>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Jogo>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Jogo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.caminhoLink)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.nomePerfil)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Perfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Studio>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Studio>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Studio>()
                .Property(e => e.emali)
                .IsUnicode(false);

            modelBuilder.Entity<Studio>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Studio)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.idUsuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Studio1)
                .WithOptional(e => e.Usuario1)
                .HasForeignKey(e => e.idUsuario);
        }
    }
}
