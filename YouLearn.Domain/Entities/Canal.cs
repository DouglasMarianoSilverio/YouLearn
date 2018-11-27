using System;

namespace YouLearn.Domain.Entities
{
    public class Canal
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string UrlLogo { get; private set; }
        public Usuario Usuario { get; private  set; }

    }
}
