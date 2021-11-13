namespace MusicHub.Data.Models
{
    using System.Collections.Generic;

    public class Producer
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Pseudonym { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}
