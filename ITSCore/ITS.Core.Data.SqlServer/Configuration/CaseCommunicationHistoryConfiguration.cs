using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class CaseCommunicationHistoryConfiguration : EntityTypeConfiguration<CaseCommunicationHistory>
    {
        public CaseCommunicationHistoryConfiguration()
            : base()
        {
            HasKey(caseCommunicationHistory => caseCommunicationHistory.CaseCommunicationHistoryID);
            ToTable(Global.Table.global.CaseCommunicationHistory, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
