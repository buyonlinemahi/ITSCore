using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class EmailSendingOptionConfiguration : EntityTypeConfiguration<EmailSendingOption>
    {

        public EmailSendingOptionConfiguration()
            : base()
        {
            HasKey(emailSendingOption => emailSendingOption.EmailSendingOptionID);
            Property(emailSendingOption => emailSendingOption.EmailSendingOptionName);
            ToTable(Global.Table.lookup.EmailSendingOption, Global.GlobalConst.Schema.LOOKUP);

        }

    }


}
