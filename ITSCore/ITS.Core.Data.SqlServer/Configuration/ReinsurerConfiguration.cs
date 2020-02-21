using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReinsurerConfiguration : EntityTypeConfiguration<Reinsurer>
    {
        public ReinsurerConfiguration()
            : base()
        {
            HasKey(caseObj => caseObj.ReinsurerID);
            ToTable(Global.Table.lookup.Reinsurer, Global.GlobalConst.Schema.LOOKUP);      
        }
    }
}
