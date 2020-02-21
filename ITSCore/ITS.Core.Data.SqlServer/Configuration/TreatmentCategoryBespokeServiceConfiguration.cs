using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class TreatmentCategoryBespokeServiceConfiguration : EntityTypeConfiguration<TreatmentCategoryBespokeService>
    {
        public TreatmentCategoryBespokeServiceConfiguration()
            : base()
        {
            HasKey(treatmentCategoryBespokeService => treatmentCategoryBespokeService.TreatmentCategoryBespokeServiceID);
            Property(treatmentCategoryBespokeService => treatmentCategoryBespokeService.TreatmentCategoryBespokeServiceID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(treatmentCategoryBespokeService => treatmentCategoryBespokeService.TreatmentCategoryID).IsRequired();
            Property(treatmentCategoryBespokeService => treatmentCategoryBespokeService.BespokeServiceID).IsRequired();
            ToTable(Global.Table.lookup.TreatmentCategoryBespokeService, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
