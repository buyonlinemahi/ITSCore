using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface ICasePatientSupplierPractitioner
    {
        CasePatientSupplierPractitioner GetInitialAssessmentCasePatientSupplierPractitionerByCaseID(int caseID);
    }
}
