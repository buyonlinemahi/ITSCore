using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface IReferrerAuthorisationsRepository
    {
        IEnumerable<ReferrerAuthorisations> GetReferrerAuthorisationsByReferrerID(int referrerID, int userID, int skip, int take);
        int GetReferrerAuthorisationCountByReferrerID(int referrerID, int userID);
    }
}
