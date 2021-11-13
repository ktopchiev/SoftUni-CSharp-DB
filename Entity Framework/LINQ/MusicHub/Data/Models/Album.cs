namespace MusicHub.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; private set; }

        public int ProducerId { get; set; }

        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();
    }
}
