using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentPatientInjuryHistoryConfiguration : EntityTypeConfiguration<CaseAssessmentPatientInjuryHistory>
    {
        public CaseAssessmentPatientInjuryHistoryConfiguration()
            : base()
        {
            HasKey(caseAssessmentPatientInjuryHistory => caseAssessmentPatientInjuryHistory.CaseAssessmentPatientInjuryHistoryID);
            ToTable(Global.Table.global.CaseAssessmentPatientInjuryHistory, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
