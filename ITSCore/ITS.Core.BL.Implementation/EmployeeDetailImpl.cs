using ITS.Core.Data;
using ITS.Core.Data.Model;


namespace ITS.Core.BL.Implementation
{
    public class EmployeeDetailImpl : IEmployeeDetail
    {

        private readonly IEmployeeDetailRepository _employeeDetailRepository;

        public EmployeeDetailImpl(IEmployeeDetailRepository employeeDetailRepository)
        {
            _employeeDetailRepository = employeeDetailRepository;

        }

        public int AddEmployeeDetail(EmployeeDetail objDetail)
        {
            return _employeeDetailRepository.Add(objDetail).EmployeeDetailID;
        }

        public int UpdateEmployeeDetail(EmployeeDetail objDetail)
        {
            return _employeeDetailRepository.Update(objDetail, (_c => _c.EmployeeDetailID), (_c => _c.EAP), (_c => _c.DateofFirstAbsence), (_c => _c.CurrentRoleTypeID), (_c => _c.CurrentlyAbsentFromWorkID), (_c => _c.CurrentHours), (_c => _c.AgileWorkerID)
               , (_c => _c.AdditionalQuestion1), (_c => _c.AdditionalQuestion2), (_c => _c.FurtherQuestion1), (_c => _c.FurtherQuestion2), (_c => _c.IllnessEmpAbilityToPerform), (_c => _c.MedicationOrTreatment), (_c => _c.OfficeBasedID), (_c => _c.OfficeLocation), (_c => _c.PreRelatedAbsence), (_c => _c.UsualHours), (_c => _c.UsualJobRoleTypeID),
               (_c => _c.jobTitle), (_c => _c.NationalINSNumber));
        }

        public void DeleteEmployeeDetailByID(int employeeDetailID)
        {
            _employeeDetailRepository.Delete(_employeeDetailRepository.GetById(employeeDetailID));
        }

        public EmployeeDetail GetEmployeeDetailByID(int employeeDetailID)
        {
            return _employeeDetailRepository.GetById(employeeDetailID);
        }
    }
}