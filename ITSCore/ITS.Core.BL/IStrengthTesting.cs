using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IStrengthTesting
    {
        IEnumerable<StrengthTesting> GetAllStrengthTesting();
        string GetStrengthTestingDesciptionByID(int _strengthTestingID);
    }
}
