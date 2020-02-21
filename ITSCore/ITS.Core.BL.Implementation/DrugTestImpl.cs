using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
   public class DrugTestImpl:IDrugTest
    {
       private readonly IDrugTestRepository _DrugTestRepository;

        public DrugTestImpl(IDrugTestRepository DrugTestRepository)
        {
            _DrugTestRepository = DrugTestRepository;

        }

        public int AddDrugTest(DrugTest objDrug)
        {
            return _DrugTestRepository.Add(objDrug).DrugTestID;
        }

        public int UpdateDrugTest(DrugTest objDrug)
        {
            return _DrugTestRepository.UpdateDrugTest(objDrug);             
        }

        public DrugTest GetDrugTestByCaseID(int caseID)
        {
            return _DrugTestRepository.GetDrugTestByCaseID(caseID);
        }
    }
}
