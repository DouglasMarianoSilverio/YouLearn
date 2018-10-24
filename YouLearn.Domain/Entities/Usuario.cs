using System;
using YouLearn.Domain.ValueObjects;

namespace YouLearn.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public Nome nome { get; set; }
        public Email Email { get; set; }
        public string  Senha { get; set; }

    }
}
