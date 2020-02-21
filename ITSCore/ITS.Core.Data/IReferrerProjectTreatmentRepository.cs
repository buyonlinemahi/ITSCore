using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
  Page Name:  IReferrerProjectTreatmentRepository.cs                      
  Latest Version:  1.1                                              
  Purpose: Create Referrer Project Treatment Repository  interface                                                      
  Revision History:                                        
                                                           
 * 1.0 – 11/09/2012 Satya 
 * 1.1 – 11/09/2012 Satya 
 Purpose: Add/update method on Referrer Project Treatment Repository  interface  

 */
namespace ITS.Core.Data
{
    public interface IReferrerProjectTreatmentRepository : IBaseRepository<ReferrerProjectTreatment>
    {
        int AddReferrerProjectTreatment(ReferrerProjectTreatment referrerProjectTreatment);
        int UpdateReferrerProjectTreatment(ReferrerProjectTreatment referrerProjectTreatment);
        int UpdateReferrerProjectTreatments(ReferrerProjectTreatment referrerProjectTreatment);
        IEnumerable<ReferrerProjectTreatmentTreatmentCategory> GetReferrerProjectTreatmentsByReferrerProjectID(int referrerProjectID);
        ReferrerProjectTreatmentTreatmentCategory GetReferrerProjectTreatmentByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        ReferrerProjectTreatment GetReferrerProjectTreatmentExistsByReferrerProjectIDAndTreatmentCategoryID(ReferrerProjectTreatment referrerProjectTreatment);
        int GetReferrerIdAgtReferrerProjectTreatmentId(int referrerProjectTreatmentID);

    }
}
