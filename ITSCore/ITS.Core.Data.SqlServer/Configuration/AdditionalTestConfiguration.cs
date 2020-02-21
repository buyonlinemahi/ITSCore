using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
  public  class AdditionalTestConfiguration:EntityTypeConfiguration<AdditionalTest>
    {
      public AdditionalTestConfiguration()
            : base()
        {
            HasKey(additionalTest => additionalTest.AdditionalTestID);
            ToTable(Global.Table.lookup.AdditionalTest, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
