using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.BL
{
    public interface ITreatmentCategoryBespokeService
    {
        IEnumerable<TreatmentCategoryBespokeService> GetTreatmentCategoryBespokeServicesByTreatmentCategoryID(int treatmentCategoryID);
    }
}
