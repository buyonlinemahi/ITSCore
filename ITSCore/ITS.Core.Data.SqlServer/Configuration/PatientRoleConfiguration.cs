using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PatientRoleConfiguration : EntityTypeConfiguration<PatientRole>
    {
        public PatientRoleConfiguration()
            : base()
        {
            HasKey(patientRole => patientRole.PatientRoleID);
            Property(patientRole => patientRole.PatientRoleName);
            ToTable(Global.Table.lookup.PatientRole, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
