using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    /*
  Page Name:  IReferrerProjectTreatmentEmail.cs                      
  Version:  1.1                                              
  Purpose: Added,Update,Delete,GetReferrerProjectTreatmentId, GetReferrerProjectTreatmentEmailById,DeleteReferrerProjectTreatmentEmailById added methods                                                 
  Revision History:                                       
                                                           
    1.0 – 11/14/2012 Harpreet Singh  

 * Edited By   : Pardeep Kumar
 * Dated       : 07/26/2013
 * Description : Added New method GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID
 * Version     : 1.1
     * 
     */
    public interface IReferrerProjectTreatmentEmail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="referrerProjectTreatmentEmailById"></param>
        /// <returns></returns>
        ReferrerProjectTreatmentEmail GetReferrerProjectTreatmentEmailByEmailId(int id);
        IEnumerable<ReferrerProjectTreatmentEmail> GetByReferrerProjectTreatmentId(int referrerProjectTreatmentId);
        IEnumerable<ReferrerProjectTreatment> GetReferrerProjectTreatmentByTreatmentId(int referrerProjectTreatmentId);
        
        int AddReferrerProjectTreatmentEmail(ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail);
        int UpdateReferrerProjectTreatmentEmail(ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail);
        int DeleteReferrerProjectTreatmentEmailById(int referrerProjectTreatmentEmailId);
        IEnumerable<ReferrerProjectTreatmentEmailTypeName> GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
    }
}
