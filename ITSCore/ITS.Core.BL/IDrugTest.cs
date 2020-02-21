using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
   public interface IDrugTest
    {
       int AddDrugTest(DrugTest objDrug);
       int UpdateDrugTest(DrugTest objDrug);
       DrugTest GetDrugTestByCaseID(int caseID);
    }
}
