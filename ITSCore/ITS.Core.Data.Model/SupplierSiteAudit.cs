using System;
/*
Page Name:  SupplierSiteAudit.cs                      
Version:  1.0                                              
Purpose: create SupplierSiteAudit model class                                                      
Revision History:                                        
                                                           
1.0 – 12/24/2012 Vishal 

*/
namespace ITS.Core.Data.Model
{
   public class SupplierSiteAudit
    {
       public int SupplierSiteAuditID { get; set; }
       public string AuditNotes { get; set; }
       public DateTime AuditDate { get; set; }
       public bool AuditPass { get; set; }
       public int UserID { get; set; }
       public int? SupplierDocumentID { get; set; }
       public int SupplierID { get; set; }      
    }
}
