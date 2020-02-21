using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 *
 * Latest Version : 1.0
 * 
 * Author         : Pardeep Kumar
 * Date           : 15-Nov-2012
 * Version        : 1.0
 * 
 */

namespace ITS.Core.BL
{
    public interface ITreatmentCategoryPricingTypes
    {
        IEnumerable<TreatmentCategoryPricingTypes> GetPricingTypesByTreatmentCategoryID(int treatmentCategoryID);  
    }
}
