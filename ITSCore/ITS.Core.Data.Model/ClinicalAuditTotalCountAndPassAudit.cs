/*
   Page Name:  ClinicalAuditTotalCountAndPassAudit.cs                      
    Version:  1.2                                             
    Purpose: create ClinicalAuditTotalCountAndPassAudit  model class                                                      
    Revision History:                                        
                                                           
      1.0 – 04/19/2012 Satya 
 * 
   */
namespace ITS.Core.Data.Model
{
    public class ClinicalAuditTotalCountAndPassAudit
    {       
       public int SupplierID { get; set; }
       public int AuditPassCount { get; set; }
       public int SupplierClinicalAuditCount { get; set; }
    }
}
