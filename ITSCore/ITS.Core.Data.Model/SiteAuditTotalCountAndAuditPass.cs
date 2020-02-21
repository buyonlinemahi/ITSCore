/*
   Page Name:  SiteAuditTotalCountAndAuditPass.cs                      
    Version:  1.2                                             
    Purpose: create SiteAuditTotalCountAndAuditPass  model class                                                      
    Revision History:                                        
                                                           
      1.0 – 04/19/2012 Satya 
 * 
   */
namespace ITS.Core.Data.Model
{
    public class SiteAuditTotalCountAndAuditPass
    {       
       public int SupplierID { get; set; }
       public int AuditPassCount { get; set; }
       public int SiteAuditCount { get; set; }
    }
}
