using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class EmailTypeConfiguration : EntityTypeConfiguration<EmailType>
    {

        public EmailTypeConfiguration()
            : base()
        {
            HasKey(emailType => emailType.EmailTypeID);
            Property(emailType => emailType.EmailTypeName).IsRequired();
            Property(emailType => emailType.UserTypeID).IsRequired();
            ToTable(Global.Table.lookup.EmailType, Global.GlobalConst.Schema.LOOKUP);

        }

    }


}
