using Application.Inferfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Application.OpenApp
{
    public class MessageApp : IMessageApp
    {
        private readonly IMessage _IMessage;
        private readonly IServiceMessage _IServiceMessage;
        public MessageApp(IMessage iMessage, IServiceMessage serviceMessage)
        {
            _IMessage = iMessage;
            _IServiceMessage = serviceMessage;
        }
        public async Task AddMessage(Message message)
        {
            await _IServiceMessage.AddMessage(message);
        }
        public async Task UpdateMessage(Message message)
        {
            await _IServiceMessage.UpdateMessage(message);
        }
        public async Task<List<Message>> ListaMessageAtivas()
        {
            return await _IServiceMessage.ListaMessageAtivas();
        }
        public async Task Add(Message objeto)
        {
            await _IMessage.Add(objeto);
        }
        public async Task Delete(Message objeto)
        {
            await _IMessage.Delete(objeto);
        }

        public async Task<Message> GetEntityId(int id)
        {
            return await _IMessage.GetEntityId(id);
        }

        public async Task<List<Message>> List()
        {
            return await _IMessage.List();
        }
        public async Task Update(Message objeto)
        {
            await _IMessage.Update(objeto);
        }

    
    }
}
