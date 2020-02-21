using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IReinsurer
    {
        IEnumerable<Data.Model.Reinsurer> GetAllReinsurer();
    }
}
