using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReasonForReferralConfiguration : EntityTypeConfiguration<ReasonForReferral>
    {
        public ReasonForReferralConfiguration()
            : base()
        {
            HasKey(reason => reason.ReasonForReferralID);
            ToTable(Global.Table.lookup.ReasonForReferral, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
