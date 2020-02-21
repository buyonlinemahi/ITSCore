using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
   public class PasswordHistoryConfiguration:EntityTypeConfiguration<PasswordHistory>
    {
       public PasswordHistoryConfiguration()
            : base()
        {
            HasKey(PHistory => PHistory.PasswordHistoryID);
            ToTable(Global.Table.global.PasswordHistory, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
