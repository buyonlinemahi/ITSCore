using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface IReferrerAuthorisations
    {
        IEnumerable<ReferrerAuthorisations> GetReferrerAuthorisationsByReferrerID(int referrerID, int UserID, int skip, int take);
        int GetReferrerAuthorisationCountByReferrerID(int referrerID, int UserID);
    }
}
