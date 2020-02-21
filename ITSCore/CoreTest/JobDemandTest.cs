using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class JobDemandTest
    {
        IJobDemandRepository _jobDemandRepository;
        IJobDemand _jobDemand;


        [TestInitialize()]
        public void SupplierInit()
        {
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();
            _jobDemandRepository = new JobDemandRepository(baseContextFactory);
            _jobDemand = new JobDemandImpl(_jobDemandRepository);

           
        }

        [TestMethod]
        public void AddJobDemand()
        {
            JobDemand jobDemand = new JobDemand(); 
            jobDemand.IsStanding           =  false;
            jobDemand.IsWalking            =  true;
            jobDemand.IsWorkATHeightOrClimb=  false;
            jobDemand.IsExtendedOrProlonged=  true;
            jobDemand.IsVocationalDriving  =  true;
            jobDemand.IsDrivingLGVOrPCVs   =  false;
            jobDemand.IsDrivingForkliftTrucks = true;
            jobDemand.IsWorkWithChemials         =  true;
            jobDemand.IsWorkBiologicalOrChemical =  false;
            jobDemand.IsWorkWithSkinIrritants    =  true;
            jobDemand.IsWorkWithDengerousMachinery = true;
            jobDemand.IsNightWork =  false;
            jobDemand.IsShiftWork =  true;
            jobDemand.IsWorkInConfinedSpaces       =  true;
            jobDemand.IsWorkWithDustOrFumes        =  false;
            jobDemand.IsLiftOrCarryHeavyItems      =  true;
            jobDemand.IsWorkWithComputerOrScreens  =  true;
            jobDemand.IsWorkTowardsTagetOrPressuredsituation  =  false;
            jobDemand.IsWorkWithAdultOrChildren   =  true;
            jobDemand.IsHealthCareWorker  =  true;
            jobDemand.IsOccasionalOverseasTravel  =  false;
            jobDemand.IsOutsideWork               =  true;
            jobDemand.IsNoisedHarzardArea         =  false;
            jobDemand.IsHandlingFood              =  true;
            jobDemand.FreeText = "vvvvvvvvvvv";
            int res = _jobDemand.AddJobDemand(jobDemand);
            Assert.IsTrue(res != 0, "Error in inserting !!!");
        }

        [TestMethod]
        public void UpdateJobDemand()
        {
            JobDemand jobDemand = new JobDemand();
            jobDemand.JobDemandID = 1158;
            jobDemand.IsStanding = true;
            jobDemand.IsWalking = true;
            jobDemand.IsWorkATHeightOrClimb = true;
            jobDemand.IsExtendedOrProlonged = true;
            jobDemand.IsVocationalDriving = true;
            jobDemand.IsDrivingLGVOrPCVs = true;
            jobDemand.IsDrivingForkliftTrucks = true;
            jobDemand.IsWorkWithChemials = true;
            jobDemand.IsWorkBiologicalOrChemical = true;
            jobDemand.IsWorkWithSkinIrritants = true;
            jobDemand.IsWorkWithDengerousMachinery = true;
            jobDemand.IsNightWork = true;
            jobDemand.IsShiftWork = true;
            jobDemand.IsWorkInConfinedSpaces = true;
            jobDemand.IsWorkWithDustOrFumes = true;
            jobDemand.IsLiftOrCarryHeavyItems = true;
            jobDemand.IsWorkWithComputerOrScreens = true;
            jobDemand.IsWorkTowardsTagetOrPressuredsituation = true;
            jobDemand.IsWorkWithAdultOrChildren = true;
            jobDemand.IsHealthCareWorker = true;
            jobDemand.IsOccasionalOverseasTravel = true;
            jobDemand.IsOutsideWork = true;
            jobDemand.IsNoisedHarzardArea = true;
            jobDemand.IsHandlingFood = true;
            jobDemand.IsJobDemand = true;
            jobDemand.FreeText = "uuuuuuuuuu";

            int res = _jobDemand.UpdateJobDemand(jobDemand);
            Assert.IsTrue(res != 0, "Error in inserting _Supplier !!!");
        }


        [TestMethod]
        public void GetJobDemandByCaseID()
        {
            var res = _jobDemand.GetJobDemandByCaseID(1);
            Assert.IsTrue(res != null, "Error");
        }



    }

    
}
