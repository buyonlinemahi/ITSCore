using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  SupplierClinicalAuditConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create SupplierClinicalAudit Configuration to ingrtate with ITS                                                       
 Revision History:                                       
                                                           
   1.0 – 12/29/2012 Vishal   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierClinicalAuditConfiguration : EntityTypeConfiguration<SupplierClinicalAudit>
    {
        public SupplierClinicalAuditConfiguration()
            : base()
        {
            HasKey(supplierClinicalAudit => supplierClinicalAudit.SupplierClinicalAuditID);
            ToTable(Global.Table.supplier.SupplierClinicalAudit, Global.GlobalConst.Schema.SUPPLIER);
        }
    }
}
