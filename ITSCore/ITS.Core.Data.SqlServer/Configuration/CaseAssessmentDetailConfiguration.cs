
using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseAssessmentDetailConfiguration : EntityTypeConfiguration<CaseAssessmentDetail>
    {
        public CaseAssessmentDetailConfiguration()
            : base()
        {
            HasKey(modelObj => modelObj.CaseAssessmentDetailID);
            ToTable(Global.Table.global.CaseAssessmentDetail, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}