using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    
    public class CaseAssessmentConfiguration : EntityTypeConfiguration<CaseAssessment>
    {
        public CaseAssessmentConfiguration()
            : base()
        {
            HasKey(caseAssessment => caseAssessment.CaseID);
            ToTable(Global.Table.global.CaseAssessment, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
