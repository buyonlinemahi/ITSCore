using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 Page Name:  ITreatmentCategory.cs                      
  Version:  1.0                                              
  Purpose: Added a Method to Add TreatmentCategory                                                   
  Revision History:                                        
                                                           
    1.0 – 11/07/2012 Satya  

 */
namespace ITS.Core.BL
{
    public interface ITreatmentCategory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TreatmentCategory> GetAllTreatmentCategory();

        
    }
}
