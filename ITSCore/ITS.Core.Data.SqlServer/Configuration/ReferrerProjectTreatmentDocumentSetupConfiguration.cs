using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerProjectTreatmentDocumentSetupConfiguration : EntityTypeConfiguration<ReferrerProjectTreatmentDocumentSetup>
    {
        public ReferrerProjectTreatmentDocumentSetupConfiguration()
            : base()
        {
            HasKey(referrerProjectTreatmentDocumentSetup => referrerProjectTreatmentDocumentSetup.ReferrerProjectTreatmentDocumentSetupID);
            Property(referrerProjectTreatmentDocumentSetup => referrerProjectTreatmentDocumentSetup.ReferrerProjectTreatmentDocumentSetupID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrerProjectTreatmentDocumentSetup => referrerProjectTreatmentDocumentSetup.AssessmentServiceID).IsRequired();
            Property(referrerProjectTreatmentDocumentSetup => referrerProjectTreatmentDocumentSetup.DocumentSetupTypeID).IsRequired();
            Property(referrerProjectTreatmentDocumentSetup => referrerProjectTreatmentDocumentSetup.ReferrerProjectTreatmentID).IsRequired();
            ToTable(Global.Table.referrer.ReferrerProjectTreatmentDocumentSetup, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
