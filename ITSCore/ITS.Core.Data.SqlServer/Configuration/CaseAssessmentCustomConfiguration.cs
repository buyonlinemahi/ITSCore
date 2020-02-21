using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentCustomConfiguration : EntityTypeConfiguration<CaseAssessmentCustom>
    {
        public CaseAssessmentCustomConfiguration()
            : base()
        {
            HasKey(caseAssessmentCustom => caseAssessmentCustom.CaseAssessmentID);
            ToTable(Global.Table.global.CaseAssessmentCustom, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
