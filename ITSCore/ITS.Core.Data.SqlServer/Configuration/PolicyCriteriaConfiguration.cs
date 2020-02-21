using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class PolicyCriteriaConfiguration : EntityTypeConfiguration<PolicyCriteria>
    {
        public PolicyCriteriaConfiguration()
            : base()
        {
            HasKey(policyCriteria => policyCriteria.PolicyCriteriaID);
            ToTable(Global.Table.lookup.PolicyCriteria, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
