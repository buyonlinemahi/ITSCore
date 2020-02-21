using System.Collections.Generic;

namespace ITS.Core.BL
{
   public interface IReasonForReferral
    {
       IEnumerable<Data.Model.ReasonForReferral> GetAllReasonForReferral();
    }
}
