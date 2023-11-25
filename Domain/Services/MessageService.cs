using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessage _IMessage;
        public MessageService(IMessage iMessage)
        {
            _IMessage = iMessage;
        }

        public async Task AddMessage(Message message)
        {
            message.DataCadastro = DateTime.Now;
            message.DataAlteracao = DateTime.Now;
            message.Ativo = true;
            await _IMessage.Add(message);
        }
        public async Task UpdateMessage(Message message)
        {
            message.DataCadastro = DateTime.Now;
            message.DataAlteracao = DateTime.Now;
            message.Ativo = true;
            await _IMessage.Update(message);
        }
        public async Task<List<Message>> ListaMessageAtivas()
        {
            return await _IMessage.ListaMessage(n => n.Ativo);
        }

       
    }
}
