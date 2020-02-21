using ITS.Core.Data;
using System.Collections.Generic;
namespace ITS.Core.BL.Implementation
{
    public class EmploymentTypeImpl : IEmploymentType
    {
         private readonly IEmploymentTypeRepository _IEmploymentTypeRepository;

         public EmploymentTypeImpl(IEmploymentTypeRepository IEmploymentTypeRepository)
        {
            _IEmploymentTypeRepository = IEmploymentTypeRepository;
        }

         public IEnumerable<Data.Model.EmploymentType> GetAllEmploymentType()
        {
            return _IEmploymentTypeRepository.GetAll();
        }
    }
}
