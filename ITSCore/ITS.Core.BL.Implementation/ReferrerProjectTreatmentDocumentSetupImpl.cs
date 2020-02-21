using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentDocumentSetupImpl : IReferrerProjectTreatmentDocumentSetup
    {


        private readonly IReferrerProjectTreatmentDocumentSetupRepository _referrerProjectTreatmentDocumentSetupRepository;

        public ReferrerProjectTreatmentDocumentSetupImpl(IReferrerProjectTreatmentDocumentSetupRepository referrerProjectTreatmentDocumentSetupRepository)
        {
            _referrerProjectTreatmentDocumentSetupRepository = referrerProjectTreatmentDocumentSetupRepository;
        }

        public int AddReferrerProjectTreatmentDocumentSetup(ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentAssignment)
        {
            return _referrerProjectTreatmentDocumentSetupRepository.AddReferrerProjectTreatmentDocumentSetup(referrerProjectTreatmentAssignment);
        }

        public int  UpdateReferrerProjectTreatmentDocumentSetup(ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentAssignment)
        {
            return _referrerProjectTreatmentDocumentSetupRepository.UpdateReferrerProjectTreatmentDocumentSetup(referrerProjectTreatmentAssignment);
        }

        public IEnumerable<ReferrerProjectTreatmentDocumentSetup> GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            return _referrerProjectTreatmentDocumentSetupRepository.GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID(referrerProjectTreatmentID);
        }



    }
}
