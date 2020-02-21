using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
   public class DrugTestRepository: BaseRepository<DrugTest, ITSDBContext>, IDrugTestRepository
    {
       public DrugTestRepository(IContextFactory<ITSDBContext> contextFactory): base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
       {

       }

       public DrugTest GetDrugTestByCaseID(int _caseID)
       {
           SqlParameter caseID = new SqlParameter("@CaseID", _caseID);
           return Context.Database.SqlQuery<DrugTest>(Global.StoredProcedureConst.DrugTestRepositoryProcedure.GetDrugTestByCaseID, caseID).FirstOrDefault();
       }
       public int UpdateDrugTest(DrugTest objDrug)
       {
           SqlParameter[] param = {
                                       new SqlParameter("@DrugTestID", objDrug.DrugTestID),
                                       new SqlParameter("@IsDrugAndAlcohalTest", objDrug.IsDrugAndAlcohalTest),
                                       new SqlParameter("@NetworkRailStandardApplicableID", objDrug.NetworkRailStandardApplicableID),
                                       new SqlParameter("@ReasonForReferralID", objDrug.ReasonForReferralID),
                                       new SqlParameter("@IsSentinalUpdating", objDrug.IsSentinalUpdating),
                                       new SqlParameter("@SentinalNumber", (object)objDrug.SentinalNumber ?? DBNull.Value),
                                       new SqlParameter("@AdditionalTestID", objDrug.AdditionalTestID),
                                       new SqlParameter("@AdditionalTestOther", (object) objDrug.AdditionalTestOther ?? DBNull.Value)
                                   };

           return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.DrugTestRepositoryProcedure.UpdateDrugTest, param);
       }
    
   }
  
}
