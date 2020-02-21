using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface ICasePatientReferrerSupplier
    {
        CasePatientReferrerSupplier GetCasePatientReferrerSupplierByCaseID(int caseID);
    }
}
