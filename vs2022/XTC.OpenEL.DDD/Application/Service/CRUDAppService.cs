using System;
using System.Linq;
using System.Threading.Tasks;
using XTC.OpenEL.DDD.Application.DTO;
using XTC.OpenEL.DDD.Domain.Entity;
using XTC.OpenEL.DDD.Domain.Repository;

namespace XTC.OpenEL.DDD.Application.Service;

public abstract class CRUDAppService<TEntity, TEntityDTO, TKey>
: CRUDAppService<TEntity, TEntityDTO, TKey, PagedAndSortedResultRequestDTO>
where TEntity : class, IEntity<TKey>
where TEntityDTO : IEntityDTO<TKey>
{
    protected CRUDAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }
}

public abstract class CRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput>
: CRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput, TEntityDTO>
where TEntity : class, IEntity<TKey>
where TEntityDTO : IEntityDTO<TKey>
{
    protected CRUDAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }
}

public abstract class CRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput, TCreateInput>
: CRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput, TCreateInput, TCreateInput>
where TEntity : class, IEntity<TKey>
where TEntityDTO : IEntityDTO<TKey>
{
    protected CRUDAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }
}

public abstract class CRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
: CRUDAppService<TEntity, TEntityDTO, TEntityDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
where TEntity : class, IEntity<TKey>
where TEntityDTO : IEntityDTO<TKey>
{
    protected CRUDAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }

    protected override Task<TEntityDTO> MapToGetListOutputDTOAsync(TEntity entity)
    {
        return MapToGetOutputDTOAsync(entity);
    }

    protected override TEntityDTO MapToGetListOutputDTO(TEntity entity)
    {
        return MapToGetOutputDTO(entity);
    }
}

public abstract class CRUDAppService<TEntity, TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
: AbstractKeyCRUDAppService<TEntity, TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
where TEntity : class, IEntity<TKey>
where TGetOutputDTO : IEntityDTO<TKey>
where TGetListOutputDTO : IEntityDTO<TKey>
{
    protected new IRepository<TEntity, TKey> Repository { get; }

    protected CRUDAppService(IRepository<TEntity, TKey> repository)
        : base(repository)
    {
        Repository = repository;
    }

    protected override async Task DeleteByIdAsync(TKey id)
    {
        await Repository.DeleteAsync(id);
    }

    protected override async Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return await Repository.GetAsync(id);
    }

    protected override void MapToEntity(TUpdateInput updateInput, TEntity entity)
    {
        if (updateInput is IEntityDTO<TKey> entityDTO)
        {
            entityDTO.Id = entity.Id;
        }

        base.MapToEntity(updateInput, entity);
    }

    protected override IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
    {
        if (typeof(TEntity).IsAssignableTo<IHasCreationTime>())
        {
            return query.OrderByDescending(e => ((IHasCreationTime)e).CreationTime);
        }
        else
        {
            return query.OrderByDescending(e => e.Id);
        }
    }
}
