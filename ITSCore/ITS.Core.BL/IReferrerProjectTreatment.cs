using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 Page Name:  IReferrerProjectTreatment.cs                      
  Version:  1.0                                              
  Purpose: Added a Method to Add/update/Getall IReferrerProjectTreatment                                                   
  Revision History:                                        
                                                           
    1.0 – 11/09/2012 Satya  

 */
namespace ITS.Core.BL
{
    public interface IReferrerProjectTreatment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<ReferrerProjectTreatment> GetAllReferrerProjectTreatment();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="referrerProjectTreatment"></param>
        /// <returns></returns>
        int AddReferrerProjectTreatment(ReferrerProjectTreatment referrerProjectTreatment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="referrerProjectTreatment"></param>
        /// <returns></returns>
        int UpdateReferrerProjectTreatment(ReferrerProjectTreatment referrerProjectTreatment);
        int UpdateReferrerProjectTreatments(ReferrerProjectTreatment referrerProjectTreatment);
        IEnumerable<ReferrerProjectTreatmentTreatmentCategory> GetReferrerProjectTreatmentsByReferrerProjectID(int referrerProjectID);
        ReferrerProjectTreatmentTreatmentCategory GetReferrerProjectTreatmentByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        int GetReferrerIdAgtReferrerProjectTreatmentId(int referrerProjectTreatmentID);
        
    }
}
