using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Favorito : EntityBase
    {
        
        public Usuario Usuario { get; set; }
        public Video Video { get; set; }

    }
}
