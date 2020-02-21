using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IAffectedArea
    {
        IEnumerable<AffectedArea> GetAllAffectedArea();
        string GetAffectedAreaDesciptionByID(int _affectedAreaID);
    }
}
