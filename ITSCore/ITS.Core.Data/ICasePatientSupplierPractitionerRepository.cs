using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface ICasePatientSupplierPractitionerRepository : IBaseRepository<CasePatientSupplierPractitioner>
    {
        CasePatientSupplierPractitioner GetCasePatientSupplierPractitionerByCaseID(int caseID);
    }
}
