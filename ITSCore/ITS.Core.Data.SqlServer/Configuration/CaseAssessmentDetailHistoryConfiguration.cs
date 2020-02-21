
using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentDetailHistoryConfiguration : EntityTypeConfiguration<CaseAssessmentDetailHistory>
    {
        public CaseAssessmentDetailHistoryConfiguration()
            : base()
        {
            HasKey(modelObj => modelObj.CaseAssessmentDetailHistoryID);
            ToTable(Global.Table.global.CaseAssessmentDetailHistory, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}

