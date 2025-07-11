using BN.Apontamentos.Domain.Trechos.Queries;
using BN.Apontamentos.Domain.Trechos.Schemas;
using BN.Apontamentos.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BN.Apontamentos.Infrastructure.Trechos
{
    internal class ObterTrechoPorIdModelRepository
        : IRequestHandler<ObterTrechoPorIdModelQuery, Trecho>
    {
        private readonly BnDbContext dbContext;

        public ObterTrechoPorIdModelRepository(BnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Trecho> Handle(
            ObterTrechoPorIdModelQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Trecho> query = dbContext.Set<Trecho>();

            if (request.IncluirCircuito)
            {
                query = query.Include(t => t.Circuito);
            }

            if (request.IncluirPlanoDeCorte)
            {
                query = query.Include(t => t.PlanoDeCorte);
            }

            if (request.IncluirBobina)
            {
                query = query.Include(t => t.Bobina);
            }

            if (request.IncluirOrigem)
            {
                query = query.Include(t => t.Origem);
            }

            if (request.IncluirDestino)
            {
                query = query.Include(t => t.Destino);
            }

            return await query.FirstOrDefaultAsync(t => t.IdTrecho == request.IdTrecho, cancellationToken);
        }
    }
}
