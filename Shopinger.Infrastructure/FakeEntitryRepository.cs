using System.Xml.Linq;
using Bogus;
using Microsoft.Extensions.Options;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Domain.SearchCriterias;

namespace Shopinger.Infrastructure.Fakers;

public class FakeRepositoryOptions
{
    public int Count { get; set; }
}

public abstract class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : BaseClassEntity
{
    protected readonly IEnumerable<TEntity> Entities;
    
    public FakeEntityRepository(Faker<TEntity> faker, IOptions<FakeRepositoryOptions> options)
    {
        Entities = faker.Generate(options.Value.Count);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return Entities;
    }

    public TEntity GetById(int id)
    {
        return Entities.FirstOrDefault(x => x.Id == id);
    }

    public void Add(TEntity entity)
    {
        var id = Entities.Max(x => x.Id);
        entity.Id = ++id;
        Entities.Append(entity);
    }

    public void Update(TEntity entity)
    {
        var entityToUpdate = GetById(entity.Id);
        if (entityToUpdate == null)
        {
            throw new ArgumentException("Entity not found");
        }
        
        entityToUpdate.CopyProperties(entity);
    }

    public abstract IEnumerable<TEntity> Search(SearchCriteria<TEntity> criteria);

    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return Task.FromResult(GetAll());
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        return Task.FromResult(GetById(id));
    }

    public Task AddAsync(TEntity entity)
    {
        Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(TEntity entity)
    {
        try
        {
            Update(entity);
            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            return Task.FromException(e);
        }
    }
}
