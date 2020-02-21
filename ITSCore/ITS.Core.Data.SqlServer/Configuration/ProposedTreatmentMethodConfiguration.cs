using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ProposedTreatmentMethodConfiguration : EntityTypeConfiguration<ProposedTreatmentMethod>
    {
        public ProposedTreatmentMethodConfiguration()
            : base()
        {
            HasKey(proposedTreatmentMethod => proposedTreatmentMethod.ProposedTreatmentMethodID);
            Property(proposedTreatmentMethod => proposedTreatmentMethod.ProposedTreatmentMethodID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(proposedTreatmentMethod => proposedTreatmentMethod.ProposedTreatmentMethodName).IsRequired();
            ToTable(Global.Table.lookup.ProposedTreatmentMethod, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
