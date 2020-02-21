using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;




namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentDocumentSetupRepository : BaseRepository<ReferrerProjectTreatmentDocumentSetup, ITSDBContext>,IReferrerProjectTreatmentDocumentSetupRepository
    {
        public ReferrerProjectTreatmentDocumentSetupRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }
        public int AddReferrerProjectTreatmentDocumentSetup(ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentAssignment)
        {
            SqlParameter AsssessmentServiceID = new SqlParameter("@AssessmentServiceID", referrerProjectTreatmentAssignment.AssessmentServiceID);
            SqlParameter DocumentSetupTypeID = new SqlParameter("@DocumentSetupTypeID", referrerProjectTreatmentAssignment.DocumentSetupTypeID);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentAssignment.ReferrerProjectTreatmentID);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerProjectTreatmentDocumentSetupRepositoryProcedure.AddReferrerProjectTreatmentDocumentSetup, AsssessmentServiceID, DocumentSetupTypeID, ReferrerProjectTreatmentID).SingleOrDefault();
        }

        public int UpdateReferrerProjectTreatmentDocumentSetup(ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentAssignment)
        {
            SqlParameter ReferrerProjectTreatmentDocumentSetupID = new SqlParameter("@ReferrerProjectTreatmentDocumentSetupID", referrerProjectTreatmentAssignment.ReferrerProjectTreatmentDocumentSetupID);
            SqlParameter AsssessmentServiceID = new SqlParameter("@AssessmentServiceID", referrerProjectTreatmentAssignment.AssessmentServiceID);
            SqlParameter DocumentSetupTypeID = new SqlParameter("@DocumentSetupTypeID", referrerProjectTreatmentAssignment.DocumentSetupTypeID);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentAssignment.ReferrerProjectTreatmentID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentDocumentSetupRepositoryProcedure.UpdateReferrerProjectTreatmentDocumentSetup, ReferrerProjectTreatmentDocumentSetupID, AsssessmentServiceID, DocumentSetupTypeID, ReferrerProjectTreatmentID);

        }

        public IEnumerable<ReferrerProjectTreatmentDocumentSetup> GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentDocumentSetup>(Global.StoredProcedureConst.ReferrerProjectTreatmentDocumentSetupRepositoryProcedure.GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID, ReferrerProjectTreatmentID);

        }

    }
}
