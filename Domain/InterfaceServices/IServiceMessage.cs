using Domain.Entities;

namespace Domain.InterfaceServices
{
     public interface IServiceMessage 
    {
        Task AddMessage(Message message);
        Task UpdateMessage(Message message);
        Task<List<Message>> ListaMessageAtivas();
    }
}
