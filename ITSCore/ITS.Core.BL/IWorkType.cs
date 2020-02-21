using System.Collections.Generic;

namespace ITS.Core.BL
{
   public  interface IWorkType
    {
       IEnumerable<Data.Model.WorkType> GetAllWorkType();
    }
}
