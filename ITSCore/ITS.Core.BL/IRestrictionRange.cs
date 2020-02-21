using ITS.Core.Data.Model;
using System.Collections.Generic;
namespace ITS.Core.BL
{
    public interface IRestrictionRange
    {
        IEnumerable<RestrictionRange> GetAllRestrictionRange();
        string GetRestrictionRangeDesciptionByID(int _restrictionRangeID);
    }
}
