namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performsers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set;}
        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Album>(album =>
            {
                album.HasKey(a => a.Id);

                album.Property(a => a.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                album.Property(a => a.Name)
                    .HasColumnType("nvarchar(40)")
                    .IsRequired();

                album.Property(a => a.ReleaseDate)
                    .HasColumnType("datetime2")
                    .IsRequired();

                album.Property(a => a.Price)
                    .HasColumnType("decimal(18,2)")
                    .HasComputedColumnSql("SUM(Songs.Price)")
            });
        }
    }
}
