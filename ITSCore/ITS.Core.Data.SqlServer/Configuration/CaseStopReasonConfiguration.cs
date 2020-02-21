using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseStopReasonConfiguration : EntityTypeConfiguration<CaseStopReason>
    {
        public CaseStopReasonConfiguration()
            : base()
        {
            HasKey(caseStopReason => caseStopReason.CaseStopReasonID);
            Property(caseStopReason => caseStopReason.CaseStopReasonName);
            ToTable(Global.Table.lookup.CaseStopReason, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
