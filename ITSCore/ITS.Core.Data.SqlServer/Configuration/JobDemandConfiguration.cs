using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class JobDemandConfiguration : EntityTypeConfiguration<JobDemand>
    {
        public JobDemandConfiguration()
            : base()
        {

            HasKey(jobdemand => jobdemand.JobDemandID);
            ToTable(Global.Table.global.JobDemand, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
