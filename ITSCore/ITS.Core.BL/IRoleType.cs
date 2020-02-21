using System.Collections.Generic;
namespace ITS.Core.BL
{
    public interface IRoleType
    {
        IEnumerable<Data.Model.RoleType> GetAllRoleType();
    }
}
