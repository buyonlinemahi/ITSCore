using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseVATConfiguration : EntityTypeConfiguration<CaseVAT>
    {
        public CaseVATConfiguration()
            : base()
        {
            HasKey(caseVAT => caseVAT.CaseID);
            ToTable(Global.Table.global.CaseVAT, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
