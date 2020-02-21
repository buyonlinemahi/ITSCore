using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class FitForWorkConfiguration : EntityTypeConfiguration<FitForWork>
    {
        public FitForWorkConfiguration()
            : base()
        {
            HasKey(fitforWork =>fitforWork.FitforWorkID);
            ToTable(Global.Table.lookup.FitForWork, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
