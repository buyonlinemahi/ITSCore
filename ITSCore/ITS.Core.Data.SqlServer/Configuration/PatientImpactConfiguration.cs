using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{

    public class PatientImpactConfiguration : EntityTypeConfiguration<PatientImpact>
    {
        public PatientImpactConfiguration()
            : base()
        {
            HasKey(patientImpact => patientImpact.PatientImpactID);
            Property(patientImpact => patientImpact.PatientImpactName).IsRequired();
            ToTable(Global.Table.lookup.PatientImpact, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
