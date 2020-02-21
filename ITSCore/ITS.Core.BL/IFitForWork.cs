using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IFitForWork
    {
        IEnumerable<Data.Model.FitForWork> GetAllFitForWork();
    }
}
