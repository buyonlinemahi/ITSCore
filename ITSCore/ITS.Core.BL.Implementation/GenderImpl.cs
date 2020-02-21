using ITS.Core.Data;
using System.Collections.Generic;
namespace ITS.Core.BL.Implementation
{
    public class GenderImpl :IGender
    {
         private readonly IGenderRepository _IGenderRepository;

         public GenderImpl(IGenderRepository IGenderRepository)
        {
            _IGenderRepository = IGenderRepository;
        }

         public IEnumerable<Data.Model.Gender> GetAllGenderTypes()
        {
            return _IGenderRepository.GetAll();
        }
    }
}
