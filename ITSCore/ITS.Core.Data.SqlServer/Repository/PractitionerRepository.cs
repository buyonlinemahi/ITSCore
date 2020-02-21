using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class PractitionerRepository : BaseRepository<Practitioner, ITSDBContext>, IPractitionerRepository
    {
        public PractitionerRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddPractitioner(Practitioner practitioner)
        {
            SqlParameter _PractitionerFirstName = new SqlParameter("@PractitionerFirstName", practitioner.PractitionerFirstName);
            SqlParameter _PractitionerLastName = new SqlParameter("@PractitionerLastName", practitioner.PractitionerLastName);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.PractitionerRepositoryProcedures.AddPractitioner, _PractitionerFirstName, _PractitionerLastName).SingleOrDefault();
        }


        public IEnumerable<Practitioner> GetPractitionerLikePractitionerName(string practitionerFirstName)
        {
            SqlParameter _PractitionerFirstName = new SqlParameter("@PractitionerFirstName", practitionerFirstName);
            return Context.Database.SqlQuery<Practitioner>(Global.StoredProcedureConst.PractitionerRepositoryProcedures.GetPractitionerLikePractitionerName, _PractitionerFirstName);
        }

        
        public int UpdatePractitionerByPractitionerID(Practitioner practitioner)
        {
            SqlParameter PractitionerID = new SqlParameter("@PractitionerID", practitioner.PractitionerID);
            SqlParameter _PractitionerFirstName = new SqlParameter("@PractitionerFirstName", practitioner.PractitionerFirstName);
            SqlParameter _PractitionerLastName = new SqlParameter("@PractitionerLastName", practitioner.PractitionerLastName);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PractitionerRepositoryProcedures.UpdatePractitionerByPractitionerID, PractitionerID, _PractitionerFirstName, _PractitionerLastName);
        }

        public Practitioner GetPractitionerByPractitionerID(int practitionerID)
        {
            SqlParameter _practitionerID = new SqlParameter("@PractitionerID", practitionerID);
            return Context.Database.SqlQuery<Practitioner>(Global.StoredProcedureConst.PractitionerRepositoryProcedures.GetPractitionerByPractitionerID, _practitionerID).SingleOrDefault();
        }


        public int DeletePractitionerByPractitionerID(int practitionerID)
        {
            SqlParameter _practitionerID = new SqlParameter("@PractitionerID", practitionerID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PractitionerRepositoryProcedures.DeletePractitionerByPractitionerID, _practitionerID);
       
        }

        public IEnumerable<Practitioner> GetPractitionersRecentlyAdded()
        {
            return Context.Database.SqlQuery<Practitioner>(Global.StoredProcedureConst.PractitionerRepositoryProcedures.GetPractitionersRecentlyAdded);
        }

    }
}
