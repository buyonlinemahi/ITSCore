using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
   public class AdditionalTestImpl:IAdditionalTest
    {
       private readonly IAdditionalTestRepository _IAdditionalTestRepository;

       public AdditionalTestImpl(IAdditionalTestRepository IAdditionalTestRepository)
        {
            _IAdditionalTestRepository = IAdditionalTestRepository;
        }

       public IEnumerable<Data.Model.AdditionalTest> GetAllAdditionalTest()
        {
            return _IAdditionalTestRepository.GetAll();
        }
    }
}
