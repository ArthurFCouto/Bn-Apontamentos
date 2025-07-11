namespace BN.Apontamentos.Domain.UnitOfWork
{
    /// <summary>
    /// Interface que representa o padrão Unit of Work, responsável por coordenar transações
    /// e garantir que múltiplas operações de repositório sejam tratadas de forma atômica.
    /// </summary>
    public interface IUnitOfWork
    {
        public void Add(object entity);
        public Task AddAsync(object entity);
        public Task<StatusCommit> CommitAsync();
        public void RemoveAsync(object entity);
    }
}
