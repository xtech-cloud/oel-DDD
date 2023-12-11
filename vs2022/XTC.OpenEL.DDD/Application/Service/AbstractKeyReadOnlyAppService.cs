using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using XTC.OpenEL.DDD.Application.DTO;
using XTC.OpenEL.DDD.Domain.Entity;
using XTC.OpenEL.DDD.Domain.Repository;
using XTC.OpenEL.DDD.Infrastracture.Error;

namespace XTC.OpenEL.DDD.Application.Service;

public abstract class AbstractKeyReadOnlyAppService<TEntity, TEntityDTO, TKey>
: AbstractKeyReadOnlyAppService<TEntity, TEntityDTO, TEntityDTO, TKey, PagedAndSortedResultRequestDTO>
where TEntity : class, IEntity
{
    protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity> repository)
        : base(repository)
    {

    }
}

public abstract class AbstractKeyReadOnlyAppService<TEntity, TEntityDTO, TKey, TGetListInput>
: AbstractKeyReadOnlyAppService<TEntity, TEntityDTO, TEntityDTO, TKey, TGetListInput>
where TEntity : class, IEntity
{
    protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity> repository)
        : base(repository)
    {

    }
}

public abstract class AbstractKeyReadOnlyAppService<TEntity, TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput>
: AbstractApplicationService
, IReadOnlyAppService<TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput>
where TEntity : class, IEntity
{
    protected IReadOnlyRepository<TEntity> ReadOnlyRepository { get; }

    protected virtual string? GetPolicyName { get; set; }

    protected virtual string? GetListPolicyName { get; set; }

    protected AbstractKeyReadOnlyAppService(IReadOnlyRepository<TEntity> repository)
    {
        ReadOnlyRepository = repository;
    }

    public virtual async Task<TGetOutputDTO> GetAsync(TKey id)
    {
        var entity = await GetEntityByIdAsync(id);

        return await MapToGetOutputDTOAsync(entity);
    }

    public virtual async Task<PagedResultDTO<TGetListOutputDTO>> GetListAsync(TGetListInput input)
    {
        var query = await CreateFilteredQueryAsync(input);
        var totalCount = await asyncExecuter_.CountAsync(query);

        var entities = new List<TEntity>();
        var entityDTOs = new List<TGetListOutputDTO>();

        if (totalCount > 0)
        {
            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            entities = await asyncExecuter_.ToListAsync(query);
            entityDTOs = await MapToGetListOutputDTOsAsync(entities);
        }

        return new PagedResultDTO<TGetListOutputDTO>(
            totalCount,
            entityDTOs
        );
    }

    protected abstract Task<TEntity> GetEntityByIdAsync(TKey id);

    /// <summary>
    /// Should apply sorting if needed.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="input">The input.</param>
    protected virtual IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, TGetListInput input)
    {
        //Try to sort query if available
        if (input is ISortedResultRequest sortInput)
        {
            if (!sortInput.Sorting.IsNullOrWhiteSpace())
            {
                return query.OrderBy(sortInput.Sorting!);
            }
        }

        //IQueryable.Task requires sorting, so we should sort if Take will be used.
        if (input is ILimitedResultRequest)
        {
            return ApplyDefaultSorting(query);
        }

        //No sorting
        return query;
    }

    /// <summary>
    /// Applies sorting if no sorting specified but a limited result requested.
    /// </summary>
    /// <param name="query">The query.</param>
    protected virtual IQueryable<TEntity> ApplyDefaultSorting(IQueryable<TEntity> query)
    {
        if (typeof(TEntity).IsAssignableTo<IHasCreationTime>())
        {
            return query.OrderByDescending(e => ((IHasCreationTime)e).CreationTime);
        }

        throw new DDDException("No sorting specified but this query requires sorting. Override the ApplyDefaultSorting method for your application service derived from AbstractKeyReadOnlyAppService!");
    }

    /// <summary>
    /// Should apply paging if needed.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <param name="input">The input.</param>
    protected virtual IQueryable<TEntity> ApplyPaging(IQueryable<TEntity> query, TGetListInput input)
    {
        //Try to use paging if available
        if (input is IPagedResultRequest pagedInput)
        {
            return query.PageBy(pagedInput);
        }

        //Try to limit query result if available
        if (input is ILimitedResultRequest limitedInput)
        {
            return query.Take(limitedInput.MaxResultCount);
        }

        //No paging
        return query;
    }

    /// <summary>
    /// This method should create <see cref="IQueryable{TEntity}"/> based on given input.
    /// It should filter query if needed, but should not do sorting or paging.
    /// Sorting should be done in <see cref="ApplySorting"/> and paging should be done in <see cref="ApplyPaging"/>
    /// methods.
    /// </summary>
    /// <param name="input">The input.</param>
    protected virtual async Task<IQueryable<TEntity>> CreateFilteredQueryAsync(TGetListInput input)
    {
        return await ReadOnlyRepository.GetQueryableAsync();
    }

    /// <summary>
    /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TGetOutputDTO"/>.
    /// It internally calls the <see cref="MapToGetOutputDTO"/> by default.
    /// It can be overriden for custom mapping.
    /// Overriding this has higher priority than overriding the <see cref="MapToGetOutputDTO"/>
    /// </summary>
    protected virtual Task<TGetOutputDTO> MapToGetOutputDTOAsync(TEntity entity)
    {
        return Task.FromResult(MapToGetOutputDTO(entity));
    }

    /// <summary>
    /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TGetOutputDTO"/>.
    /// It uses <see cref="IObjectMapper"/> by default.
    /// It can be overriden for custom mapping.
    /// </summary>
    protected virtual TGetOutputDTO MapToGetOutputDTO(TEntity entity)
    {
        return objectMapper_.Map<TEntity, TGetOutputDTO>(entity);
    }

    /// <summary>
    /// Maps a list of <typeparamref name="TEntity"/> to <typeparamref name="TGetListOutputDTO"/> objects.
    /// It uses <see cref="MapToGetListOutputDTOAsync"/> method for each item in the list.
    /// </summary>
    protected virtual async Task<List<TGetListOutputDTO>> MapToGetListOutputDTOsAsync(List<TEntity> entities)
    {
        var DTOs = new List<TGetListOutputDTO>();

        foreach (var entity in entities)
        {
            DTOs.Add(await MapToGetListOutputDTOAsync(entity));
        }

        return DTOs;
    }

    /// <summary>
    /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TGetListOutputDTO"/>.
    /// It internally calls the <see cref="MapToGetListOutputDTO"/> by default.
    /// It can be overriden for custom mapping.
    /// Overriding this has higher priority than overriding the <see cref="MapToGetListOutputDTO"/>
    /// </summary>
    protected virtual Task<TGetListOutputDTO> MapToGetListOutputDTOAsync(TEntity entity)
    {
        return Task.FromResult(MapToGetListOutputDTO(entity));
    }

    /// <summary>
    /// Maps <typeparamref name="TEntity"/> to <typeparamref name="TGetListOutputDTO"/>.
    /// It uses <see cref="IObjectMapper"/> by default.
    /// It can be overriden for custom mapping.
    /// </summary>
    protected virtual TGetListOutputDTO MapToGetListOutputDTO(TEntity entity)
    {
        return objectMapper_.Map<TEntity, TGetListOutputDTO>(entity);
    }
}