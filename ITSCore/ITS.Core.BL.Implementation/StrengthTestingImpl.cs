using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class StrengthTestingImpl :IStrengthTesting
    {
        private readonly IStrengthTestingRepository _StrengthTestingRepository;

        public StrengthTestingImpl(IStrengthTestingRepository StrengthTestingRepository)
        {
            _StrengthTestingRepository = StrengthTestingRepository;
        }

        public IEnumerable<Data.Model.StrengthTesting> GetAllStrengthTesting()
        {
            return _StrengthTestingRepository.GetAll();
        }
        public string GetStrengthTestingDesciptionByID(int _strengthTestingID)
        {
            return _StrengthTestingRepository.GetById(_strengthTestingID).StrengthTestingDescription;
        }
    }
   
}
