using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierTreatmentConfiguration : EntityTypeConfiguration<SupplierTreatment>
    {

        public SupplierTreatmentConfiguration()
            : base()
        {
            HasKey(supplierTreatment => supplierTreatment.SupplierTreatmentID);

            ToTable(Global.Table.supplier.SupplierTreatment, Global.GlobalConst.Schema.SUPPLIER);

        }
    }
}
