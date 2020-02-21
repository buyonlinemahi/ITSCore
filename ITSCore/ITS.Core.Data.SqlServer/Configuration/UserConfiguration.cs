using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
            : base()
        {
            HasKey(user => user.UserID);
            ToTable(Global.Table.global.User, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}