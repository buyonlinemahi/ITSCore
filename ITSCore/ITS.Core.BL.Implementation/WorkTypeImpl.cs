using ITS.Core.Data;
using System.Collections.Generic;
namespace ITS.Core.BL.Implementation
{
    public class WorkTypeImpl : IWorkType
    {

           private readonly IWorkTypeRepository _IWorkTypeRepository;

           public WorkTypeImpl(IWorkTypeRepository IWorkTypeRepository)
        {
            _IWorkTypeRepository = IWorkTypeRepository;
        }

         public IEnumerable<Data.Model.WorkType> GetAllWorkType()
        {
            return _IWorkTypeRepository.GetAll();
        }
    }
}
