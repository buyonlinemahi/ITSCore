using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
   Page Name:  SupplierClinicalAudit.cs                      
    Version:  1.2                                             
    Purpose: create SupplierClinicalAudit  model class                                                      
    Revision History:                                        
                                                           
      1.0 – 12/29/2012 Vishal 
 * 
 * 
 * Modified by    : Pardeep Kumar
 * Date           : 25-Jan-2013
 * Latest version : 1.1
 * Description    : Updated the data type of SupplierClinicalAuditStatus from String to Boolean
 * 
 * Modified by    : Pardeep Kumar
 * Date           : 11-Feb-2013
 * Latest version : 1.2
 * Description    : Removed the property named ReferrerID

   */
namespace ITS.Core.Data.Model
{
   public class SupplierClinicalAudit
    {       
       public int SupplierClinicalAuditID { get; set; }
       public int SupplierID { get; set; }
       public Boolean AuditPass { get; set; }
       public int UserID { get; set; }
       public DateTime AuditDate { get; set; }
       public int CaseID { get; set; }
       public int SupplierDocumentID { get; set; }  
    }
}
