using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IAdmitted
    {
        IEnumerable<Data.Model.Admitted> GetAllAdmitted();
    }
}
