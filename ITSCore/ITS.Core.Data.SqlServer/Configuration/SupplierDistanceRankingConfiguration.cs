using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierDistanceRankingConfiguration : EntityTypeConfiguration<SupplierDistanceRanking>
    {
        public SupplierDistanceRankingConfiguration()
            : base()
        {
        }
    }
}