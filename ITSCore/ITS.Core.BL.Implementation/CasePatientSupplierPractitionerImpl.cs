using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{

    public class CasePatientSupplierPractitionerImpl : ICasePatientSupplierPractitioner
    {

        private readonly ICasePatientSupplierPractitionerRepository _casePatientSupplierPractitionerRepository;


        public CasePatientSupplierPractitionerImpl(ICasePatientSupplierPractitionerRepository casePatientSupplierPractitionerRepository)
        {
            _casePatientSupplierPractitionerRepository = casePatientSupplierPractitionerRepository;
        }


        public CasePatientSupplierPractitioner GetInitialAssessmentCasePatientSupplierPractitionerByCaseID(int caseID)
        {
            return _casePatientSupplierPractitionerRepository.GetCasePatientSupplierPractitionerByCaseID(caseID);
        }
    }
}
