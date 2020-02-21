using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer
{
    public class PolicyOpenDetailConfiguration : EntityTypeConfiguration<PolicyOpenDetail>
    {
        public PolicyOpenDetailConfiguration()
            : base()
        {
            HasKey(PolicyOpenDetail => PolicyOpenDetail.PolicyOpenDetailID);
            ToTable(Global.Table.global.PolicyOpenDetail, Global.GlobalConst.Schema.GLOBAL);    
        }
    }
}
