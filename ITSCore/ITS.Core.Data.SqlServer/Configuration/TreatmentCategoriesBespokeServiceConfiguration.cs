using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TreatmentCategoriesBespokeServiceConfiguration : EntityTypeConfiguration<TreatmentCategoriesBespokeService>
    {
        public TreatmentCategoriesBespokeServiceConfiguration()
            : base()
        {
            HasKey(treatmentCategoriesBespokeService => treatmentCategoriesBespokeService.TreatmentCategoryBespokeServiceID);
            Property(treatmentCategoriesBespokeService => treatmentCategoriesBespokeService.TreatmentCategoryName).IsRequired();
            Property(treatmentCategoriesBespokeService => treatmentCategoriesBespokeService.BespokeServiceName).IsRequired();
            Property(treatmentCategoriesBespokeService => treatmentCategoriesBespokeService.TreatmentCategoryID).IsRequired();
            Property(treatmentCategoriesBespokeService => treatmentCategoriesBespokeService.BespokeServiceID).IsRequired();
            ToTable(Global.View.lookup.TreatmentCategoriesBespokeService, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
