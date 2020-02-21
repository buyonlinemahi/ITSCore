using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
   public class ReasonForReferralImpl:IReasonForReferral
    {
       private readonly IReasonForReferralRepository _IReasonForReferralRepository;

       public ReasonForReferralImpl(IReasonForReferralRepository IReasonForReferralRepository)
        {
            _IReasonForReferralRepository = IReasonForReferralRepository;
        }

       public IEnumerable<Data.Model.ReasonForReferral> GetAllReasonForReferral()
        {
            return _IReasonForReferralRepository.GetAll();
        }
    }
}
