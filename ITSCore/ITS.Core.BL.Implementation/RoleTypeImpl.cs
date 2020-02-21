using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class RoleTypeImpl : IRoleType
    {
         private readonly IRoleTypeRepository _IRoleTypeRepository;

         public RoleTypeImpl(IRoleTypeRepository IRoleTypeRepository)
        {
            _IRoleTypeRepository = IRoleTypeRepository;
        }

         public IEnumerable<Data.Model.RoleType> GetAllRoleType()
        {
            return _IRoleTypeRepository.GetAll();
        }
    }
}
