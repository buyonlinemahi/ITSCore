using ITS.Core.Data;

namespace ITS.Core.BL.Implementation
{
    public class CasePatientReferrerSupplierImpl : ICasePatientReferrerSupplier
    {
        private readonly ICasePatientReferrerSupplierRepository _casePatientReferrerSupplier;

        public CasePatientReferrerSupplierImpl(ICasePatientReferrerSupplierRepository casePatientReferrerSupplier)
        {
            _casePatientReferrerSupplier = casePatientReferrerSupplier;
        }

        public Data.Model.CasePatientReferrerSupplier GetCasePatientReferrerSupplierByCaseID(int caseID)
        {
            return _casePatientReferrerSupplier.GetCasePatientReferrerSupplierByCaseID(caseID);
        }
    }
}
