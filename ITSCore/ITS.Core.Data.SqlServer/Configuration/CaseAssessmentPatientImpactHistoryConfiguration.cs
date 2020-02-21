using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentPatientImpactHistoryConfiguration : EntityTypeConfiguration<CaseAssessmentPatientImpactHistory>
    {
        public CaseAssessmentPatientImpactHistoryConfiguration()
            : base()
        {
            HasKey(caseAssessmentPatientImpactHistory => caseAssessmentPatientImpactHistory.CaseAssessmentPatientImpactHistoryID);
            ToTable(Global.Table.global.CaseAssessmentPatientImpactHistory, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
