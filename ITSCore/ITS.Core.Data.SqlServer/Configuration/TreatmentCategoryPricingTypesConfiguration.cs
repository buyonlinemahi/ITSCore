using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TreatmentCategoryPricingTypesConfiguration : EntityTypeConfiguration<TreatmentCategoryPricingTypes>
    {
        public TreatmentCategoryPricingTypesConfiguration()
            : base()
        {
            HasKey(TreatmentCategoryPricingTypes => TreatmentCategoryPricingTypes.TreatmentCategoryPricingTypeID);
            ToTable(Global.Table.lookup.TreatmentCategoryPricingType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
