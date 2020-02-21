using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

/*
Page Name:  SupplierSiteAuditConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create SupplierSiteAuditConfiguration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 12/24/2012 Vishal   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
  
    public class SupplierSiteAuditConfiguration : EntityTypeConfiguration<SupplierSiteAudit>
    {
        public SupplierSiteAuditConfiguration()
            : base()
        {
            HasKey(supplierSiteAudit => supplierSiteAudit.SupplierSiteAuditID);          
            ToTable(Global.Table.supplier.SupplierSiteAudit, Global.GlobalConst.Schema.SUPPLIER);
        }
    }
}
