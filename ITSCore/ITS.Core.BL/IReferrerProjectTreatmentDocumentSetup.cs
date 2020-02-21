using System;
using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{

    public interface IReferrerProjectTreatmentDocumentSetup
    {

        int AddReferrerProjectTreatmentDocumentSetup(ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentAssignment);
        int UpdateReferrerProjectTreatmentDocumentSetup(ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentAssignment);
        IEnumerable<ReferrerProjectTreatmentDocumentSetup> GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID(int referrerProjectTreatmentID);

    }
}
