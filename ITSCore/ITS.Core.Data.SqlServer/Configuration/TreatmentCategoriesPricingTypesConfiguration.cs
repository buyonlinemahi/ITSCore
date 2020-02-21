using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TreatmentCategoriesPricingTypesConfiguration:EntityTypeConfiguration<TreatmentCategoriesPricingTypes>
    {
        public TreatmentCategoriesPricingTypesConfiguration()
            : base()
        {
            HasKey(pricingType => pricingType.TreatmentCategoryPricingTypeID);
           // Property(treatmentCategoryID => treatmentCategoryID.TreatmentCategoryID);
            ToTable(Global.View.lookup.TreatmentCategoriesPricingTypes, Global.GlobalConst.Schema.LOOKUP);
        }
    }
    
}
