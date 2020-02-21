using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseReferrerAssignedUserConfiguration: EntityTypeConfiguration<CaseReferrerAssignedUser>
    {
        public CaseReferrerAssignedUserConfiguration()
            : base()
        {
            HasKey(caseAssignUser => caseAssignUser.CaseReferrerAssignedUserID);
            ToTable(Global.Table.global.CaseReferrerAssignedUser, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
