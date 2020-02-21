using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierTreatmentPricingConfiguration : EntityTypeConfiguration<SupplierTreatmentPricing>
    {
        public SupplierTreatmentPricingConfiguration()
            : base()
        {
            HasKey(supplierTreatmentPricing => supplierTreatmentPricing.PricingID);
            ToTable(Global.Table.supplier.SupplierTreatmentPricing, Global.GlobalConst.Schema.SUPPLIER);
          
         

        }

    }
}
