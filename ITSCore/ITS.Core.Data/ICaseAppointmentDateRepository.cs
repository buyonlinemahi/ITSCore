using System.Collections.Generic;
using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface ICaseAppointmentDateRepository : IBaseRepository<CaseAppointmentDate>
    {
        int AddCaseAppointmentDate(CaseAppointmentDate caseAppointmentDate);
        int UpdateCaseAppointmentDate(CaseAppointmentDate caseAppointmentDate);
        CaseAppointmentDate GetCaseAppointmentDateByCaseID(int caseID);
    }
}
