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
        public DbSet<Performer> Performers { get; set; }
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

                album
                    .HasOne(a => a.Producer)
                    .WithMany(a => a.Albums)
                    .HasForeignKey(a => a.ProducerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Performer>(performer =>
            {
                performer.HasKey(p => p.Id);

                performer.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                performer.Property(p => p.FirstName)
                    .HasColumnType("nvarchar(20)")
                    .IsRequired(true);

                performer.Property(p => p.LastName)
                    .HasColumnType("nvarchar(20)")
                    .IsRequired();

                performer.Property(p => p.Age)
                    .HasColumnType("int")
                    .IsRequired();

                performer.Property(p => p.NetWorth)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });

            builder.Entity<Producer>(producer =>
            {
                producer.HasKey(p => p.Id);

                producer.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                producer.Property(p => p.Name)
                    .HasColumnType("nvarchar(30)")
                    .IsRequired();

                producer.Property(p => p.Pseudonym)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired(false);

                producer.Property(p => p.PhoneNumber)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired(false);
            });

            builder.Entity<Song>(song =>
            {
                song.HasKey(p => p.Id);

                song.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                song.Property(s => s.Name)
                    .HasColumnType("nvarchar(20)")
                    .IsRequired();

                song.Property(s => s.Duration)
                    .HasColumnType("bigint")
                    .IsRequired();

                song.Property(s => s.CreatedOn)
                    .HasColumnType("datetime2")
                    .IsRequired();

                song.Property(s => s.Genre)
                    .HasConversion<string>()
                    .IsRequired();

                song.HasCheckConstraint("CHK_Genre", "Genre IN ('Blues', 'Rap', 'PopMusic', 'Rock', 'Jazz')");

                song
                    .HasOne(s => s.Album)
                    .WithMany(s => s.Songs)
                    .HasForeignKey(s => s.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict);

                song
                    .HasOne(s => s.Writer)
                    .WithMany(s => s.Songs)
                    .HasForeignKey(s => s.WriterId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                song.Property(s => s.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();
            });

            builder.Entity<SongPerformer>(sp =>
            {
                sp.HasKey(sp => new { sp.PerformerId, sp.SongId});

                sp
                    .HasOne(s => s.Song)
                    .WithMany(s => s.SongPerformers)
                    .HasForeignKey(s => s.SongId)
                    .OnDelete(DeleteBehavior.Restrict);

                sp
                    .HasOne(p => p.Performer)
                    .WithMany(s => s.PerformerSongs)
                    .HasForeignKey(s => s.PerformerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Writer>(writer =>
            {
                writer.HasKey(writer => writer.Id);

                writer.Property(w => w.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                writer.Property(w => w.Name)
                    .HasColumnType("nvarchar(20)");

                writer.Property(w => w.Pseudonym)
                    .HasColumnType("nvarchar(max)");
            });
        }
    }
}
