using System;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.PlayList
{
    public class PlayListResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public static explicit operator PlayListResponse(Entities.PlayList entity)
        {
            return new PlayListResponse { Id = entity.Id, Nome = entity.Nome };
        }
    }
}
