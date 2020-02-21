using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierSearchConfiguration : EntityTypeConfiguration<SupplierSearch>
    {
        public SupplierSearchConfiguration()
            : base()
        {
            HasKey(supplierSearch => new { supplierSearch.SupplierID});
            Property(supplierSearch => supplierSearch.SupplierName);
            Property(supplierSearch => supplierSearch.SupplierID);
            Property(supplierSearch => supplierSearch.PostCode);
            Property(supplierSearch => supplierSearch.TreatmentCategoryName);
            ToTable(Global.View.supplier.SupplierSearch, Global.GlobalConst.Schema.SUPPLIER);

        }
    }
}
