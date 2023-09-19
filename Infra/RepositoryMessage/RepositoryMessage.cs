using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Infra.RepositoryGeneric;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.RepositoryMessage
{
    public class RepositoryMessage : RepositoryGeneric<Message>, IMessage
    {
        private readonly DbContextOptions<Contexto> _dbContextOptions;
        public RepositoryMessage()
        {
            _dbContextOptions = new DbContextOptions<Contexto>();
        }
        public async Task<List<Message>> ListaMessage(Expression<Func<Message, bool>> exMessage)
        {
           using (var banco = new Contexto(_dbContextOptions))
            {
                return await banco.Message.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
