using System.Data.Entity.ModelConfiguration;
using ITS.Core.Data.Model;

namespace ITS.Core.Data.SqlServer.Configuration
{

    public class CaseContactConfiguration : EntityTypeConfiguration<CaseContact>
    {
        public CaseContactConfiguration()
        {
            HasKey(caseContact => caseContact.CaseContactID);
            Property(caseContact => caseContact.CaseID).IsRequired();
            Property(caseContact => caseContact.UserID).IsRequired();
            ToTable(Global.Table.global.CaseContact, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
