using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
   public interface IDrugTestRepository:IBaseRepository<DrugTest>
    {
       DrugTest GetDrugTestByCaseID(int _caseID);
       int UpdateDrugTest(DrugTest objDrug);
    }
}
