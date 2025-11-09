namespace FileUploadService.mapper
{
    /// <summary>
    /// Сопоставляет обьект dto и entity
    /// </summary>
    /// <typeparam name="Dto">DTO</typeparam>
    /// <typeparam name="Entity">Entity</typeparam>
    public interface IMapper<Dto, Entity>
    {
        Dto ToDto(Entity entity);
        Entity ToEntity(Dto dto);
    }
}