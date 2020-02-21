using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseAppointmentDateRepository : BaseRepository<CaseAppointmentDate, ITSDBContext>, ICaseAppointmentDateRepository
    {
        public CaseAppointmentDateRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddCaseAppointmentDate(CaseAppointmentDate caseAppointmentDate)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseAppointmentDate.CaseID);
            SqlParameter _appointmentDateTime = new SqlParameter("@AppointmentDateTime", caseAppointmentDate.AppointmentDateTime);
            SqlParameter _firstAppointmentOfferedDate = new SqlParameter("@FirstAppointmentOfferedDate", caseAppointmentDate.FirstAppointmentOfferedDate.HasValue ? (object)caseAppointmentDate.FirstAppointmentOfferedDate.Value : System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAppointmentDateRepositoryProcedures.AddCaseAppointmentDate, _caseID, _appointmentDateTime, _firstAppointmentOfferedDate);

            
        }
        public int UpdateCaseAppointmentDate(CaseAppointmentDate caseAppointmentDate)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseAppointmentDate.CaseID);
            SqlParameter _appointmentDateTime = new SqlParameter("@AppointmentDateTime", caseAppointmentDate.AppointmentDateTime);
            SqlParameter _firstAppointmentOfferedDate = new SqlParameter("@FirstAppointmentOfferedDate", caseAppointmentDate.FirstAppointmentOfferedDate.HasValue ? (object)caseAppointmentDate.FirstAppointmentOfferedDate.Value : System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.CaseAppointmentDateRepositoryProcedures.UpdateCaseAppointmentDate, _caseID, _appointmentDateTime, _firstAppointmentOfferedDate);
        }

        public CaseAppointmentDate GetCaseAppointmentDateByCaseID(int caseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", caseID);
            return Context.Database.SqlQuery<CaseAppointmentDate>(Global.StoredProcedureConst.CaseAppointmentDateRepositoryProcedures.GetCaseAppointmentDateByCaseID, _caseID).FirstOrDefault();
        }
    }
}
