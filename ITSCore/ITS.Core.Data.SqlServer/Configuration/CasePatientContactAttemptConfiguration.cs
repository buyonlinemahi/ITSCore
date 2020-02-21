using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CasePatientContactAttemptConfiguration : EntityTypeConfiguration<CasePatientContactAttempt>
    {
        public CasePatientContactAttemptConfiguration()
            : base()
        {
            HasKey(casePatientContactAttemptID => casePatientContactAttemptID.CasePatientContactAttemptID);
            ToTable(Global.Table.global.CasePatientContactAttempt, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
