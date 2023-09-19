using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IMessage : IGeneric<Message>
    {
        Task<List<Message>> ListaMessage(Expression<Func<Message, bool>> exMessage);
    }
}
