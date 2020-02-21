using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentPatientImpactConfiguration : EntityTypeConfiguration<CaseAssessmentPatientImpact>
    {
        public CaseAssessmentPatientImpactConfiguration()
            : base()
        {
            HasKey(caseAssessmentPatientImpact => caseAssessmentPatientImpact.CaseAssessmentPatientImpactID);
            ToTable(Global.Table.global.CaseAssessmentPatientImpact, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
