
using System;
namespace ITS.Core.Data.Model
{
    /*
    Page Name:  Referrer.cs                      
     Version:  1.2                                              
     Purpose: create referrer model class                                                      
     Revision History:                                        
                                                           
       1.0 – 10/26/2012 Satya 
     * 1.1 - 10/26/2012 Manjit Singh
 * Data type change for ReferrerCentralEmail
     * 
     Modified By --harpreet singh
     Purpose : added the ReferrerMainContactFax and ReferrerMainContactPhone fields
     Modified date: 27-feb-2013
     
     version 1.2    */
    /// <summary>
    /// 
    /// </summary>
    public class Referrer
    {
        public int ReferrerID { get; set; }
        public string ReferrerName { get; set; }
        public string ReferrerContactFirstName { get; set; }
        public string ReferrerContactLastName { get; set; }
        public string ReferrerMainContactEmail { get; set; }
        public string ReferrerMainContactFax { get; set; }
        public string ReferrerMainContactPhone { get; set; }
        public DateTime DateAdded { get; set; }
        public bool? IsPolicyDetail { get; set; }
        public bool? IsEmploymentDetail { get; set; }
        public bool? IsEmploeeDetail { get; set; }
        public bool? IsDrugandAlcoholTest { get; set;}
        public bool? IsRepresentation { get; set;}
        public bool? IsAdditionalQuestion { get; set; }
        public bool? IsJobDemand { get; set; }
        public string IsPolicyDetailOpenOrDropdowns { get; set; }
        public string IsNewPolicyTypes { get; set; }
    }
}

