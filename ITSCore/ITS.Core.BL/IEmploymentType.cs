using System.Collections.Generic;
namespace ITS.Core.BL
{
    public interface IEmploymentType
    {
        IEnumerable<Data.Model.EmploymentType> GetAllEmploymentType();
    }
}
