using Domain.Entities;

namespace Application.Inferfaces
{
    public interface IMessageApp : IGenericApp<Message>
    {
        Task AddMessage(Message message);
        Task UpdateMessage(Message message);
        Task<List<Message>> ListaMessageAtivas();
    }
}
