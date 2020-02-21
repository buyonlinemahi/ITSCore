using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierComplaintConfiguration : EntityTypeConfiguration<SupplierComplaint>
    {

        public SupplierComplaintConfiguration()
            : base()
        {
            HasKey(supplierComplaint => supplierComplaint.SupplierComplaintID);

            ToTable(Global.Table.supplier.SupplierComplaints, Global.GlobalConst.Schema.SUPPLIER);

        }
    }
}
