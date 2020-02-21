using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
  public  class DrugTestConfiguration: EntityTypeConfiguration<DrugTest>
    {
      public DrugTestConfiguration()
            : base()
        {
            HasKey(drugtest => drugtest.DrugTestID);
            ToTable(Global.Table.global.DrugTest, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
