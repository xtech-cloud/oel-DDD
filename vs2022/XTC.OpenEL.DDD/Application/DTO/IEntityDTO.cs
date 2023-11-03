namespace XTC.OpenEL.DDD.Application.DTO;

public interface IEntityDTO
{

}

public interface IEntityDTO<TKey> : IEntityDTO
{
    TKey Id { get; set; }
}
