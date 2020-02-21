using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{

    public class PatientImpactValueConfiguration : EntityTypeConfiguration<PatientImpactValue>
    {
        public PatientImpactValueConfiguration()
            : base()
        {
            HasKey(patientImpactValue => patientImpactValue.PatientImpactValueID);
            Property(patientImpactValue => patientImpactValue.PatientImpactValueName).IsRequired();
            ToTable(Global.Table.lookup.PatientImpactValue, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
