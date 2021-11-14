namespace MusicHub.Data.Models
{
    using System.Collections.Generic;

    public class Performer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set;}

        public int Age { get; set; }

        public decimal NetWorth { get; set; }

        public ICollection<SongPerformer> PerformerSongs { get; set; } = new HashSet<SongPerformer>();
    }
}
