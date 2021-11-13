namespace MusicHub.Data.Models
{
    using System.Collections.Generic;

    public class Writer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
