using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessage _message;
        private readonly IMessageService _messageService;

        public MessageController(IMapper mapper, IMessage message, IMessageService messageService)
        {
            _mapper = mapper;
            _message = message;
            _messageService = messageService;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var mensagens = await _message.List();
            var messageMap = _mapper.Map<List<MessageViewModel>>(mensagens);

            return Ok(messageMap);
        }
        [Authorize]
        [Produces("application/json")]
        [HttpPost("add")]
        public async Task<IActionResult> Add(MessageViewModel message)
        {
            var messageMap = _mapper.Map<Message>(message);
            await _messageService.AddMessage(messageMap);

            return Ok(_mapper.Map<MessageViewModel>(messageMap));
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(MessageViewModel message)
        {
            var messageMap = _mapper.Map<Message>(message);
            await _messageService.UpdateMessage(messageMap);

            return Ok(_mapper.Map<MessageViewModel>(messageMap));
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(MessageViewModel message)
        {
            var messageMap = _mapper.Map<Message>(message);
            await _message.Delete(messageMap);

            return Ok(_mapper.Map<MessageViewModel>(messageMap));
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityById(int id)
        {
            var message = await _message.GetEntityId(id);
            var messageMap = _mapper.Map<MessageViewModel>(message);

            return Ok(messageMap);
        }

       

        [Authorize]
        [Produces("application/json")]
        [HttpGet("listar-message-ativas")]
        public async Task<IActionResult> ListarMessageAtivas()
        {
            var mensagens = await _messageService.ListaMessageAtivas();
            var messageMap = _mapper.Map<List<MessageViewModel>>(mensagens);

            return Ok(messageMap);
        }
    }
}
