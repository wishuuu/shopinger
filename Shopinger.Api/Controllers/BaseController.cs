using Microsoft.AspNetCore.Mvc;
using Shopinger.Domain;
using Shopinger.Domain.Repositories;
using Shopinger.Domain.SearchCriterias;

namespace Shopinger.Api.Controllers;

[Route("api/[controller]")]
public abstract class BaseController<TEntity> : ControllerBase
    where TEntity : BaseClassEntity
{
    private readonly IEntityRepository<TEntity> _entityRepository;
    
    public BaseController(IEntityRepository<TEntity> entityRepository)
    {
        _entityRepository = entityRepository;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_entityRepository.GetAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var entity = _entityRepository.GetById(id);
        if (entity == null)
            return NotFound();
        return Ok(entity);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] TEntity entity)
    {
        if (entity == null)
            return BadRequest();
        _entityRepository.Add(entity);
        return CreatedAtRoute("Get", new { id = entity.Id }, entity);
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TEntity entity)
    {
        if (entity == null || entity.Id != id)
            return BadRequest();
        var customerExists = _entityRepository.GetById(id);
        if (customerExists == null)
            return NotFound();
        _entityRepository.Update(entity);
        return NoContent();
    }
    
    [HttpGet("search")]
    protected IActionResult Search(SearchCriteria<TEntity> criteria)
    {
        return Ok(_entityRepository.Search(criteria));
    }
}