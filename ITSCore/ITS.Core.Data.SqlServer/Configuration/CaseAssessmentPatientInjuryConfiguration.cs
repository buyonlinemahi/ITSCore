using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentPatientInjuryConfiguration : EntityTypeConfiguration<CaseAssessmentPatientInjury>
    {
        public CaseAssessmentPatientInjuryConfiguration()
            : base()
        {
            HasKey(caseassessmentpatienInjury => caseassessmentpatienInjury.CaseAssessmentPatientInjuryID);
            ToTable(Global.Table.global.CaseAssessmentPatientInjury, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
