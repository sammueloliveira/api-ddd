using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMessage _message;
        private readonly IServiceMessage _serviceMessage;

        public MessageController(IMapper mapper, IMessage message, IServiceMessage serviceMessage)
        {
            _mapper = mapper;
            _message = message;
            _serviceMessage = serviceMessage;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            var mensagens = await _message.List();
            var messageMap = _mapper.Map<List<MessageViewModel>>(mensagens);

            return Ok(messageMap);
        }
        [Authorize]
        [Produces("application/json")]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(MessageViewModel message)
        {
            var messageMap = _mapper.Map<Message>(message);
            await _serviceMessage.AddMessage(messageMap);

            return Ok(_mapper.Map<MessageViewModel>(messageMap));
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(MessageViewModel message)
        {
            var messageMap = _mapper.Map<Message>(message);
            await _serviceMessage.UpdateMessage(messageMap);

            return Ok(_mapper.Map<MessageViewModel>(messageMap));
        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(MessageViewModel message)
        {
            var messageMap = _mapper.Map<Message>(message);
            await _message.Delete(messageMap);

            return Ok(_mapper.Map<MessageViewModel>(messageMap));
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("GetEntityById")]
        public async Task<IActionResult> GetEntityById(int id)
        {
            var message = await _message.GetEntityId(id);
            var messageMap = _mapper.Map<MessageViewModel>(message);

            return Ok(messageMap);
        }

       

        [Authorize]
        [Produces("application/json")]
        [HttpGet("ListarMessageAtivas")]
        public async Task<IActionResult> ListarMessageAtivas()
        {
            var mensagens = await _serviceMessage.ListaMessageAtivas();
            var messageMap = _mapper.Map<List<MessageViewModel>>(mensagens);

            return Ok(messageMap);
        }
    }
}
