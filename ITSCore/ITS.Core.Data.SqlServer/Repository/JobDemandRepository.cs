using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class JobDemandRepository : BaseRepository<JobDemand, ITSDBContext>, IJobDemandRepository
    {
        public JobDemandRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddJobDemand(JobDemand objJobDemand)
        {
            SqlParameter[] sqlparam = {
                                        new SqlParameter("@IsStanding", objJobDemand.IsStanding)
                                       , new SqlParameter("@IsJobDemand", objJobDemand.IsJobDemand)
                                       ,new SqlParameter("@IsWalking", objJobDemand.IsWalking)
                                       , new SqlParameter("@IsWorkATHeightOrClimb", objJobDemand.IsWorkATHeightOrClimb)
                                       ,new SqlParameter("@IsExtendedOrProlonged", objJobDemand.IsExtendedOrProlonged)
                                       ,new SqlParameter("@IsVocationalDriving", objJobDemand.IsVocationalDriving)
                                       , new SqlParameter("@IsDrivingLGVOrPCVs", objJobDemand.IsDrivingLGVOrPCVs)
                                       ,new SqlParameter("@IsDrivingForkliftTrucks", objJobDemand.IsDrivingForkliftTrucks)
                                       ,new SqlParameter("@IsWorkWithChemials", objJobDemand.IsWorkWithChemials)
                                       , new SqlParameter("@IsWorkBiologicalOrChemical", objJobDemand.IsWorkBiologicalOrChemical)
                                       ,new SqlParameter("@IsWorkWithSkinIrritants", objJobDemand.IsWorkWithSkinIrritants)
                                       ,new SqlParameter("@IsWorkWithDengerousMachinery", objJobDemand.IsWorkWithDengerousMachinery)
                                       , new SqlParameter("@IsNightWork", objJobDemand.IsNightWork)
                                       ,new SqlParameter("@IsShiftWork", objJobDemand.IsShiftWork)
                                       ,new SqlParameter("@IsWorkInConfinedSpaces", objJobDemand.IsWorkInConfinedSpaces)
                                       , new SqlParameter("@IsWorkWithDustOrFumes", objJobDemand.IsWorkWithDustOrFumes)
                                       ,new SqlParameter("@IsLiftOrCarryHeavyItems", objJobDemand.IsLiftOrCarryHeavyItems)
                                       , new SqlParameter("@IsWorkWithComputerOrScreens", objJobDemand.IsWorkWithComputerOrScreens)
                                       ,new SqlParameter("@IsWorkTowardsTagetOrPressuredsituation", objJobDemand.IsWorkTowardsTagetOrPressuredsituation)
                                        ,new SqlParameter("@IsWorkWithAdultOrChildren", objJobDemand.IsWorkWithAdultOrChildren)
                                       , new SqlParameter("@IsHealthCareWorker", objJobDemand.IsHealthCareWorker)
                                       ,new SqlParameter("@IsOccasionalOverseasTravel", objJobDemand.IsOccasionalOverseasTravel)
                                        ,new SqlParameter("@IsOutsideWork", objJobDemand.IsOutsideWork)
                                       , new SqlParameter("@IsNoisedHarzardArea", objJobDemand.IsNoisedHarzardArea)
                                       ,new SqlParameter("@IsHandlingFood", objJobDemand.IsHandlingFood)
                                       ,new SqlParameter("@FreeText", (object) objJobDemand.FreeText ?? DBNull.Value)
                                      };
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.JobDemandRepositoryProcedure.AddJobDemand, sqlparam).SingleOrDefault();

        }

        public int UpdateJobDemand(JobDemand objJobDemand)
        {

            SqlParameter[] sqlparam = {
                                        new SqlParameter("@JobDemandID", objJobDemand.JobDemandID)
                                       ,new SqlParameter("@IsJobDemand", objJobDemand.IsJobDemand)
                                       ,new SqlParameter("@IsStanding", objJobDemand.IsStanding)
                                       ,new SqlParameter("@IsWalking", objJobDemand.IsWalking)
                                       ,new SqlParameter("@IsWorkATHeightOrClimb", objJobDemand.IsWorkATHeightOrClimb)
                                       ,new SqlParameter("@IsExtendedOrProlonged", objJobDemand.IsExtendedOrProlonged)
                                       ,new SqlParameter("@IsVocationalDriving", objJobDemand.IsVocationalDriving)
                                       ,new SqlParameter("@IsDrivingLGVOrPCVs", objJobDemand.IsDrivingLGVOrPCVs)
                                       ,new SqlParameter("@IsDrivingForkliftTrucks", objJobDemand.IsDrivingForkliftTrucks)
                                       ,new SqlParameter("@IsWorkWithChemials", objJobDemand.IsWorkWithChemials)
                                       ,new SqlParameter("@IsWorkBiologicalOrChemical", objJobDemand.IsWorkBiologicalOrChemical)
                                       ,new SqlParameter("@IsWorkWithSkinIrritants", objJobDemand.IsWorkWithSkinIrritants)
                                       ,new SqlParameter("@IsWorkWithDengerousMachinery", objJobDemand.IsWorkWithDengerousMachinery)
                                       ,new SqlParameter("@IsNightWork", objJobDemand.IsNightWork)
                                       ,new SqlParameter("@IsShiftWork", objJobDemand.IsShiftWork)
                                       ,new SqlParameter("@IsWorkInConfinedSpaces", objJobDemand.IsWorkInConfinedSpaces)
                                       ,new SqlParameter("@IsWorkWithDustOrFumes", objJobDemand.IsWorkWithDustOrFumes)
                                       ,new SqlParameter("@IsLiftOrCarryHeavyItems", objJobDemand.IsLiftOrCarryHeavyItems)
                                       ,new SqlParameter("@IsWorkWithComputerOrScreens", objJobDemand.IsWorkWithComputerOrScreens)
                                       ,new SqlParameter("@IsWorkTowardsTagetOrPressuredsituation", objJobDemand.IsWorkTowardsTagetOrPressuredsituation)
                                       ,new SqlParameter("@IsWorkWithAdultOrChildren", objJobDemand.IsWorkWithAdultOrChildren)
                                       ,new SqlParameter("@IsHealthCareWorker", objJobDemand.IsHealthCareWorker)
                                       ,new SqlParameter("@IsOccasionalOverseasTravel", objJobDemand.IsOccasionalOverseasTravel)
                                       ,new SqlParameter("@IsOutsideWork", objJobDemand.IsOutsideWork)
                                       ,new SqlParameter("@IsNoisedHarzardArea", objJobDemand.IsNoisedHarzardArea)
                                       ,new SqlParameter("@IsHandlingFood", objJobDemand.IsHandlingFood)
                                       ,new SqlParameter("@FreeText", (object) objJobDemand.FreeText ?? DBNull.Value)
                                      };
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.JobDemandRepositoryProcedure.Update_JobDemandByID, sqlparam);
        }

        public JobDemand GetJobDemandByCaseID(int _caseID)
        {
            SqlParameter caseID = new SqlParameter("@CaseID", _caseID);
            return Context.Database.SqlQuery<JobDemand>(Global.StoredProcedureConst.JobDemandRepositoryProcedure.GetJobDemandByCaseID, caseID).FirstOrDefault();
        }




    }
}
