using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CaseWorkflowCountRepository : BaseRepository<CaseWorkflowCount, ITSDBContext>, ICaseWorkflowCountRepository
    {
        public CaseWorkflowCountRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


       public IEnumerable<CaseWorkflowCount> GetCaseCounts()
        {
            return
                Context.Database.SqlQuery<CaseWorkflowCount>(
                    Global.StoredProcedureConst.CaseCountRepositoryProcedures.GetCaseCounts);
        }



       public IEnumerable<CaseWorkflowCount> GetCaseCountByTreatmentCategoryID(int treatmentCategoryID)
       {
           SqlParameter _treatmentCategoryID = new SqlParameter("@TreatmentCategoryID", treatmentCategoryID);
           return
                Context.Database.SqlQuery<CaseWorkflowCount>(
                    Global.StoredProcedureConst.CaseCountRepositoryProcedures.GetCaseCountByTreatmentCategoryID,_treatmentCategoryID);
       }
    }
    }

