using System;
using System.Linq;
using System.Threading.Tasks;
using XTC.OpenEL.DDD.Application.DTO;
using XTC.OpenEL.DDD.Domain.Entity;
using XTC.OpenEL.DDD.Domain.Repository;

namespace XTC.OpenEL.DDD.Application.Service;

public abstract class ReadOnlyAppService<TEntity, TEntityDTO, TKey>
: ReadOnlyAppService<TEntity, TEntityDTO, TEntityDTO, TKey, PagedAndSortedResultRequestDTO>
where TEntity : class, IEntity<TKey>
where TEntityDTO : IEntityDTO<TKey>
{
    protected ReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }
}

public abstract class ReadOnlyAppService<TEntity, TEntityDTO, TKey, TGetListInput>
: ReadOnlyAppService<TEntity, TEntityDTO, TEntityDTO, TKey, TGetListInput>
where TEntity : class, IEntity<TKey>
where TEntityDTO : IEntityDTO<TKey>
{
    protected ReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository)
        : base(repository)
    {

    }
}

public abstract class ReadOnlyAppService<TEntity, TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput>
: AbstractKeyReadOnlyAppService<TEntity, TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput>
where TEntity : class, IEntity<TKey>
where TGetOutputDTO : IEntityDTO<TKey>
where TGetListOutputDTO : IEntityDTO<TKey>
{
    protected IReadOnlyRepository<TEntity, TKey> Repository { get; }

    protected ReadOnlyAppService(IReadOnlyRepository<TEntity, TKey> repository)
    : base(repository)
    {
        Repository = repository;
    }

    protected override async Task<TEntity> GetEntityByIdAsync(TKey id)
    {
        return await Repository.GetAsync(id);
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
