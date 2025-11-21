using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLNotes.Mapper
{
    public interface IMapper<Entity, Dto> where Dto : class where Entity : class
    {
        Entity ToEntity(Dto dto);
        Dto ToDto(Entity entity);
    }
}
