using System;

namespace YouLearn.Domain.Entities
{
    public class Favorito
    {
        public Guid Id { get; set; }
        public Usuario Usuario { get; set; }
        public Video Video { get; set; }

    }
}
