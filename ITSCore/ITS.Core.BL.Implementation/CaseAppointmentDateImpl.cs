using ITS.Core.Data;

namespace ITS.Core.BL.Implementation
{


    public class CaseAppointmentDateImpl : ICaseAppointmentDate
    {
        private readonly ICaseAppointmentDateRepository _caseAppointmentDatRepository;

        public CaseAppointmentDateImpl(ICaseAppointmentDateRepository caseAppointmentDatRepository)
        {
            _caseAppointmentDatRepository = caseAppointmentDatRepository;
        }

        public int AddCaseAppointmentDate(Data.Model.CaseAppointmentDate caseAppointmentDate)
        {
            return _caseAppointmentDatRepository.AddCaseAppointmentDate(caseAppointmentDate);
        }

        public int UpdateCaseAppointmentDate(Data.Model.CaseAppointmentDate caseAppointmentDate)
        {
            return _caseAppointmentDatRepository.UpdateCaseAppointmentDate(caseAppointmentDate);
        }

        public Data.Model.CaseAppointmentDate GetCaseAppointmentDateByCaseID(int caseID)
        {
            return _caseAppointmentDatRepository.GetCaseAppointmentDateByCaseID(caseID);
        }
    }
}
