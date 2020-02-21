using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerAuthorisationsConfiguration : EntityTypeConfiguration<ReferrerAuthorisations>
    {
        public ReferrerAuthorisationsConfiguration()
            : base()
        {
            HasKey(referrerAuthorisations => referrerAuthorisations.CaseID);
            ToTable(Global.View.referrer.ReferrerAuthorisations, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
