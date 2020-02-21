using ITS.Core.Data.Model;
/*
Page Name:  IClinicalAuditTotalCountAndPassAuditRepository.cs                      
Version:  1.0                                              
Purpose: GetClinicalAuditTotalCountAndPassAuditsBySupplierID added methods                                                 
Revision History:                                        
                                                           
  1.0 – 04/19/2013 Satya
   */
namespace ITS.Core.Data
{
    public interface IClinicalAuditTotalCountAndPassAuditRepository
    {
        ClinicalAuditTotalCountAndPassAudit GetClinicalAuditTotalCountAndPassAuditsBySupplierID(int supplierID);
    }
}
