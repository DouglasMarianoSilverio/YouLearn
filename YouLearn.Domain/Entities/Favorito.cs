using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Favorito : EntityBase
    {
        protected Favorito() 
        {
        }
        public Usuario Usuario { get; private  set; }
        public Video Video { get; private set; }

    }
}
