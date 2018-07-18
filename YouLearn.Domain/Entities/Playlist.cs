using System;

namespace YouLearn.Domain.Entities
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public string  Status { get; set; }


    }
}
