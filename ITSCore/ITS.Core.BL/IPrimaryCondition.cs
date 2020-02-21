using System.Collections.Generic;

namespace ITS.Core.BL
{
   public interface IPrimaryCondition
    {
        IEnumerable<Data.Model.PrimaryCondition> GetAllPrimaryCondition();
    }
}
