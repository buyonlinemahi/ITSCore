using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

#region Comments
 
/*
 * Latest Version : 1.0
 * 
 * Author  : Pardeep Kumar
 * Date    : 24-Dec-2012
 * Version : 1.0
 * 
 */

#endregion

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierInsuranceConfiguration : EntityTypeConfiguration<SupplierInsurance>
    {
        public SupplierInsuranceConfiguration()
            : base()
        {
            HasKey(supplierInsurance => supplierInsurance.SupplierInsuredID);
            ToTable(Global.Table.supplier.SupplierInsurance, Global.GlobalConst.Schema.SUPPLIER);
        }
    }
}
