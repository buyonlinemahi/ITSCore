using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentHistoryConfiguration : EntityTypeConfiguration<CaseAssessmentHistory>
    {
        public CaseAssessmentHistoryConfiguration()
            : base()
        {
            HasKey(caseAssessmentHistory => caseAssessmentHistory.CaseAssessmentHistoryID);
            ToTable(Global.Table.global.CaseAssessmentHistory, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
