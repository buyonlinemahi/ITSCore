using ITS.Core.Data.Model;
/*
Page Name:  ISiteAuditTotalCountAndAuditPassRepository.cs                      
Version:  1.0                                              
Purpose:  GetSiteAuditTotalCountAndAuditPassBySupplierID added methods                                                 
Revision History:                                        
                                                           
  1.0 – 04/19/2013 Satya
   */
namespace ITS.Core.Data
{
    public interface ISiteAuditTotalCountAndAuditPassRepository
    {
        SiteAuditTotalCountAndAuditPass GetSiteAuditTotalCountAndAuditPassBySupplierID(int supplierID);
    }
}
