using Domain.Entities;

namespace Domain.InterfaceServices
{
     public interface IMessageService 
    {
        Task AddMessage(Message message);
        Task UpdateMessage(Message message);
        Task<List<Message>> ListaMessageAtivas();
    }
}
