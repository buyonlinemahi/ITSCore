using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class ReferrerAuthorisationsImpl : IReferrerAuthorisations
    {
        private readonly IReferrerAuthorisationsRepository _referrerAuthorisationsRepository;

        public ReferrerAuthorisationsImpl(IReferrerAuthorisationsRepository referrerAuthorisationsRepository)
        {
            _referrerAuthorisationsRepository = referrerAuthorisationsRepository;
        }

        public IEnumerable<Data.Model.ReferrerAuthorisations> GetReferrerAuthorisationsByReferrerID(int referrerID, int UserID, int skip, int take)
        {
            return _referrerAuthorisationsRepository.GetReferrerAuthorisationsByReferrerID(referrerID, UserID, skip, take);
        }

        public int GetReferrerAuthorisationCountByReferrerID(int referrerID,int UserID)
        {
            return _referrerAuthorisationsRepository.GetReferrerAuthorisationCountByReferrerID(referrerID, UserID);
        }
    }
}
