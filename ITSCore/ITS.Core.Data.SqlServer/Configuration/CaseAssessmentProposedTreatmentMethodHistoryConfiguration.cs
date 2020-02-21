using System.Data.Entity.ModelConfiguration;
using ITS.Core.Data.Model;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentProposedTreatmentMethodHistoryConfiguration : EntityTypeConfiguration<CaseAssessmentProposedTreatmentMethodHistory>
    {
        public CaseAssessmentProposedTreatmentMethodHistoryConfiguration()
            : base()
        {
            HasKey(caseAssessmentProposedTreatmentMethodHistory => caseAssessmentProposedTreatmentMethodHistory.CaseAssessmentProposedTreatmentMethodHistoryID);
            ToTable(Global.Table.global.CaseAssessmentProposedTreatmentMethodHistory, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}