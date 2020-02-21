using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.Data
{
    public interface IReferrerProjectTreatmentDocumentSetupRepository : IBaseRepository<ReferrerProjectTreatmentDocumentSetup>
    {

        int AddReferrerProjectTreatmentDocumentSetup(ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentAssignment);
        int UpdateReferrerProjectTreatmentDocumentSetup(ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentAssignment);
        IEnumerable<ReferrerProjectTreatmentDocumentSetup> GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        
       

    }
}
