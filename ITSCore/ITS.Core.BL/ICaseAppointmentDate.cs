using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface ICaseAppointmentDate
    {
        int AddCaseAppointmentDate(CaseAppointmentDate caseAppointmentDate);
        int UpdateCaseAppointmentDate(CaseAppointmentDate caseAppointmentDate);
        CaseAppointmentDate GetCaseAppointmentDateByCaseID(int caseID);
    }
}
