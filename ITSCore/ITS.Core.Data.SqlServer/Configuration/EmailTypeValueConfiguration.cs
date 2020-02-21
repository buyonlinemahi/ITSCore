using System.Data.Entity.ModelConfiguration;
using ITS.Core.Data.Model;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class EmailTypeValueConfiguration : EntityTypeConfiguration<EmailTypeValue>
    {
        public EmailTypeValueConfiguration()
            : base()
        {
            HasKey(EmailTypeValue => EmailTypeValue.EmailTypeValueID);

            ToTable(Global.Table.lookup.EmailTypeValue, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
