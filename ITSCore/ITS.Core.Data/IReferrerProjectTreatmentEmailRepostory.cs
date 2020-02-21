using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    /*
Page Name:  IReferrerProjectTreatmentEmail.cs                      
Version:  1.1                                              
Purpose: Added,Update,Delete,GetReferrerProjectTreatmentId, GetReferrerProjectTreatmentEmailById,DeleteReferrerProjectTreatmentEmailById added methods                                                 
Revision History:                                        
                                                           
  1.0 – 11/14/2012 Harpreet Singh  
     * 
 * Edited By   : Pardeep Kumar
 * Dated       : 07/26/2013
 * Description : Added New method GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID
 * Version     : 1.1
   */
    public interface IReferrerProjectTreatmentEmailRepostory : IBaseRepository<ReferrerProjectTreatmentEmail>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="referrerProjectTreatmentEmailById"></param>
        /// <returns></returns>
        /// 
        IEnumerable<ReferrerProjectTreatmentEmail> GetByReferrerProjectTreatmentId(int referrerProjectTreatmentId);
        IEnumerable<ReferrerProjectTreatment> GetReferrerProjectTreatmentByTreatmentId(int referrerProjectTreatmentId);
        int AddReferrerProjectTreatmentEmail(ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail);
        int UpdateReferrerProjectTreatmentEmail(ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail);
        int DeleteReferrerProjectTreatmentEmailById(int referrerProjectTreatmentEmailId);
        IEnumerable<ReferrerProjectTreatmentEmailTypeName> GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID(int referrerProjectTreatmentID);


        int GetReferrerIdAgtReferrerProjectTreatmentId(int referrerProjectTreatmentId);
    }
}
