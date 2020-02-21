using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;



namespace ITS.Core.Data.SqlServer.Repository
{
    public class PractitionerExpertiseRepository : BaseRepository<PractitionerExpertise, ITSDBContext>, IPractitionerExpertiseRepository
    {
        public PractitionerExpertiseRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddPractitionerExpertise(PractitionerExpertise practitionerExpertise)
        {
            SqlParameter _PractitionerID = new SqlParameter("@PractitionerID", practitionerExpertise.PractitionerID);
            SqlParameter _AreaofExpertiseID = new SqlParameter("@AreaofExpertiseID", practitionerExpertise.AreaofExpertiseID);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.PractitionerExpertiseRepositoryProcedures.AddPractitionerExpertise, _PractitionerID, _AreaofExpertiseID).SingleOrDefault();

        }


        public PractitionerExpertise GetPractitionerExpertiseByPractitionerExpertiseID(int practitionerExpertiseID)
        {
            SqlParameter _practitionerExpertiseID = new SqlParameter("@PractitionerExpertiseID", practitionerExpertiseID);

            return Context.Database.SqlQuery<PractitionerExpertise>(Global.StoredProcedureConst.PractitionerExpertiseRepositoryProcedures.GetPractitionerExpertiseByPractitionerExpertiseID, _practitionerExpertiseID).SingleOrDefault();
        }

        public IEnumerable<PractitionerExpertise> GetPractitionerExpertiseByPractitionerID(int practitionerID)
        {
            SqlParameter _practitionerID = new SqlParameter("@PractitionerID", practitionerID);
            return Context.Database.SqlQuery<PractitionerExpertise>(Global.StoredProcedureConst.PractitionerExpertiseRepositoryProcedures.GetPractitionerExpertiseByPractitionerID, _practitionerID);
        }

        public IEnumerable<PractitionerExpertise> GetPractitionerExpertiseByAreaofExpertiseID(int areaofExpertiseID)
        {
            SqlParameter _areaofExpertiseID = new SqlParameter("@AreaofExpertiseID", areaofExpertiseID);
            return Context.Database.SqlQuery<PractitionerExpertise>(Global.StoredProcedureConst.PractitionerExpertiseRepositoryProcedures.GetPractitionerExpertiseByAreaofExpertiseID, _areaofExpertiseID);
        }

        public int DeletePractitionerExpertiseByPractitionerExpertiseID(int practitionerExpertiseID)
        {
            SqlParameter _practitionerExpertiseID = new SqlParameter("@PractitionerExpertiseID", practitionerExpertiseID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PractitionerExpertiseRepositoryProcedures.DeletePractitionerExpertiseByPractitionerExpertiseID, _practitionerExpertiseID);
        }

        public int DeletePractitionerExpertiseByPractitionerID(int practitionerID)
        {
            SqlParameter _practitionerID = new SqlParameter("@PractitionerID", practitionerID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PractitionerExpertiseRepositoryProcedures.DeletePractitionerExpertiseByPractitionerID, _practitionerID);
        }

        public int UpdatePractitionerExpertiseByPractitionerExpertiseID(PractitionerExpertise practitionerExpertise)
        {
            SqlParameter PractitionerExpertiseID = new SqlParameter("@PractitionerExpertiseID", practitionerExpertise.PractitionerExpertiseID);
            SqlParameter PractitionerID = new SqlParameter("@PractitionerID", practitionerExpertise.PractitionerID);
            SqlParameter AreaofExpertiseID = new SqlParameter("@AreaofExpertiseID", practitionerExpertise.AreaofExpertiseID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.PractitionerExpertiseRepositoryProcedures.UpdatePractitionerExpertiseByPractitionerExpertiseID, PractitionerExpertiseID, PractitionerID, AreaofExpertiseID);
        }
    }
}
