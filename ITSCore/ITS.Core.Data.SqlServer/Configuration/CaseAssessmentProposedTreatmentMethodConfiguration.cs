using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentProposedTreatmentMethodConfiguration : EntityTypeConfiguration<CaseAssessmentProposedTreatmentMethod>
    {
        public CaseAssessmentProposedTreatmentMethodConfiguration()
            : base()
        {
            HasKey(caseAssessmentProposedTreatmentMethod => caseAssessmentProposedTreatmentMethod.CaseID);
            HasKey(caseAssessmentProposedTreatmentMethod => caseAssessmentProposedTreatmentMethod.ProposedTreatmentMethodID);
            ToTable(Global.Table.global.CaseAssessmentProposedTreatmentMethod, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
