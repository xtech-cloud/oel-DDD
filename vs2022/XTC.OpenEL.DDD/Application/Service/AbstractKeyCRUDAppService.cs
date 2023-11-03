using System;
using System.Threading.Tasks;
using XTC.OpenEL.DDD.Application.DTO;
using XTC.OpenEL.DDD.Domain.Entity;
using XTC.OpenEL.DDD.Domain.Repository;

namespace XTC.OpenEL.DDD.Application.Service;

public abstract class AbstractKeyCRUDAppService<TEntity, TEntityDTO, TKey>
    : AbstractKeyCRUDAppService<TEntity, TEntityDTO, TKey, PagedAndSortedResultRequestDTO>
    where TEntity : class, IEntity
{
    protected AbstractKeyCRUDAppService(IRepository<TEntity> repository)
        : base(repository)
    {

    }
}

public abstract class AbstractKeyCRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput>
    : AbstractKeyCRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput, TEntityDTO, TEntityDTO>
    where TEntity : class, IEntity
{
    protected AbstractKeyCRUDAppService(IRepository<TEntity> repository)
        : base(repository)
    {

    }
}

public abstract class AbstractKeyCRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput, TCreateInput>
    : AbstractKeyCRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput, TCreateInput, TCreateInput>
    where TEntity : class, IEntity
{
    protected AbstractKeyCRUDAppService(IRepository<TEntity> repository)
        : base(repository)
    {

    }
}

public abstract class AbstractKeyCRUDAppService<TEntity, TEntityDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
    : AbstractKeyCRUDAppService<TEntity, TEntityDTO, TEntityDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
    where TEntity : class, IEntity
{
    protected AbstractKeyCRUDAppService(IRepository<TEntity> repository)
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

public abstract class AbstractKeyCRUDAppService<TEntity, TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
    : AbstractKeyReadOnlyAppService<TEntity, TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput>,
        ICRUDAppService<TGetOutputDTO, TGetListOutputDTO, TKey, TGetListInput, TCreateInput, TUpdateInput>
    where TEntity : class, IEntity
{
    protected IRepository<TEntity> Repository { get; }

    protected virtual string? CreatePolicyName { get; set; }

    protected virtual string? UpdatePolicyName { get; set; }

    protected virtual string? DeletePolicyName { get; set; }

    protected AbstractKeyCRUDAppService(IRepository<TEntity> repository)
        : base(repository)
    {
        Repository = repository;
    }

    public virtual async Task<TGetOutputDTO> CreateAsync(TCreateInput input)
    {
        //await CheckCreatePolicyAsync();

        var entity = await MapToEntityAsync(input);

        await Repository.InsertAsync(entity, autoSave: true);

        return await MapToGetOutputDTOAsync(entity);
    }

    public virtual async Task<TGetOutputDTO> UpdateAsync(TKey id, TUpdateInput input)
    {
        //await CheckUpdatePolicyAsync();

        var entity = await GetEntityByIdAsync(id);
        //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
        await MapToEntityAsync(input, entity);
        await Repository.UpdateAsync(entity, autoSave: true);

        return await MapToGetOutputDTOAsync(entity);
    }

    public virtual async Task DeleteAsync(TKey id)
    {
        //await CheckDeletePolicyAsync();

        await DeleteByIdAsync(id);
    }

    protected abstract Task DeleteByIdAsync(TKey id);

    /// <summary>
    /// Maps <typeparamref name="TCreateInput"/> to <typeparamref name="TEntity"/> to create a new entity.
    /// It uses <see cref="MapToEntity(TCreateInput)"/> by default.
    /// It can be overriden for custom mapping.
    /// Overriding this has higher priority than overriding the <see cref="MapToEntity(TCreateInput)"/>
    /// </summary>
    protected virtual Task<TEntity> MapToEntityAsync(TCreateInput createInput)
    {
        return Task.FromResult(MapToEntity(createInput));
    }

    /// <summary>
    /// Maps <typeparamref name="TCreateInput"/> to <typeparamref name="TEntity"/> to create a new entity.
    /// It uses <see cref="IObjectMapper"/> by default.
    /// It can be overriden for custom mapping.
    /// </summary>
    protected virtual TEntity MapToEntity(TCreateInput createInput)
    {
        var entity = objectMapper_.Map<TCreateInput, TEntity>(createInput);
        return entity;
    }

    /// <summary>
    /// Maps <typeparamref name="TUpdateInput"/> to <typeparamref name="TEntity"/> to update the entity.
    /// It uses <see cref="MapToEntity(TUpdateInput, TEntity)"/> by default.
    /// It can be overriden for custom mapping.
    /// Overriding this has higher priority than overriding the <see cref="MapToEntity(TUpdateInput, TEntity)"/>
    /// </summary>
    protected virtual Task MapToEntityAsync(TUpdateInput updateInput, TEntity entity)
    {
        MapToEntity(updateInput, entity);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Maps <typeparamref name="TUpdateInput"/> to <typeparamref name="TEntity"/> to update the entity.
    /// It uses <see cref="IObjectMapper"/> by default.
    /// It can be overriden for custom mapping.
    /// </summary>
    protected virtual void MapToEntity(TUpdateInput updateInput, TEntity entity)
    {
        objectMapper_.Map(updateInput, entity);
    }
}
