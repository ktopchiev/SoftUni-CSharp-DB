namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    TotalPrice = a.Price,
                    AlbumSongs = a.Songs
                    .Select(s => new
                    {
                        s.Name,
                        s.Price,
                        Writer = s.Writer.Name
                    })
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var album in albums.OrderByDescending(a => a.TotalPrice))
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                int counter = 1;

                foreach (var song in album.AlbumSongs
                                            .OrderByDescending(s => s.Name)
                                            .ThenBy(s => s.Writer))
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration > TimeSpan.FromSeconds(duration))
                .Select(s => new
                {
                    Name = s.Name,
                    WriterName = s.Writer.Name,
                    Performer = s.SongPerformers.Select(s => new
                    {
                        FullName = s.Performer.FirstName + " " + s.Performer.LastName,
                    })
                    .FirstOrDefault()
                    .FullName,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .ToList();



            StringBuilder sb = new StringBuilder();

            var counter = 1;

            foreach (var song in songs
                                    .OrderBy(s => s.Name)
                                    .ThenBy(s => s.WriterName)
                                    .ThenBy(s => s.Performer))
            {
                sb.AppendLine($"-Song #{counter}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c")}");
                counter++;
            }

            return sb.ToString().Trim();
        }
    }
}
