using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IGender
    {
        IEnumerable<Data.Model.Gender> GetAllGenderTypes();
    }
}
