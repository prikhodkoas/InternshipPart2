using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadService
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
