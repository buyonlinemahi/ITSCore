using System.Data.Entity.ModelConfiguration;

using ITS.Core.Data.Model;

namespace ITS.Core.Data.SqlServer.Configuration
{
    

    public class CaseHistoryConfiguration : EntityTypeConfiguration<CaseHistory>
    {
         public CaseHistoryConfiguration()
         {
            HasKey(caseObj => caseObj.CaseHistoryID);
            ToTable(Global.Table.global.CaseHistory, Global.GlobalConst.Schema.GLOBAL);
        }
    }

   
}
