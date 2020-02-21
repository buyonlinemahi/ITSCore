using ITS.Core.Data.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PatientLevelOfRecoveryConfiguration : EntityTypeConfiguration<PatientLevelOfRecovery>
    {
        public PatientLevelOfRecoveryConfiguration()
            : base()
        {
            HasKey(patientLevelOfRecovery => patientLevelOfRecovery.PatientLevelOfRecoveryID);
            Property(patientLevelOfRecovery => patientLevelOfRecovery.PatientLevelOfRecoveryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(patientLevelOfRecovery => patientLevelOfRecovery.PatientLevelOfRecoveryName).IsRequired();
            ToTable(Global.Table.lookup.PatientLevelOfRecovery, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
