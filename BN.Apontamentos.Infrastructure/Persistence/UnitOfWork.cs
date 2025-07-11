using BN.Apontamentos.Domain.UnitOfWork;
using BN.Apontamentos.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BN.Apontamentos.Infrastructure.Persistence
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly BnDbContext dbContext;

        public UnitOfWork(BnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(object entity)
        {
            dbContext.Add(entity);
        }

        public async Task AddAsync(object entity)
        {
            await dbContext.AddAsync(entity);
        }

        public async Task<StatusCommit> CommitAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();
                return StatusCommit.Sucesso;
            }
            catch (DbUpdateException)
            {
                return StatusCommit.Falha;
            }
        }

        public void RemoveAsync(object entity)
        {
            dbContext.Remove(entity);
        }
    }
}
