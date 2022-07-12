using Shopinger.Domain.SearchCriterias;

namespace Shopinger.Domain.Repositories;

public interface IEntityRepository <TEntity>
    where TEntity : BaseClassEntity
{
    IEnumerable<TEntity> GetAll();
    TEntity GetById(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    IEnumerable<TEntity> Search(SearchCriteria<TEntity> criteria);

    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
}