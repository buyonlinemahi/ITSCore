using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PolicyTypeConfiguration : EntityTypeConfiguration<PolicyType>
    {
        public PolicyTypeConfiguration()
            : base()
        {
            HasKey(policyType => policyType.PolicyTypeID);
            ToTable(Global.Table.lookup.PolicyType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
