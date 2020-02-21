using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerDocumentConfiguration : EntityTypeConfiguration<ReferrerDocument>
    {
        public ReferrerDocumentConfiguration()
            : base()
        {
            HasKey(referrerDocument => referrerDocument.ReferrerDocumentID);
            Property(referrerDocument => referrerDocument.ReferrerDocumentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(referrerDocument => referrerDocument.ReferrerID).IsRequired();
            Property(referrerDocument => referrerDocument.DocumentTypeID).IsRequired();
            Property(referrerDocument => referrerDocument.UploadDate).IsRequired();
            Property(referrerDocument => referrerDocument.UserID).IsRequired();
            Property(referrerDocument => referrerDocument.UploadPath).IsRequired();
            ToTable(Global.Table.referrer.ReferrerDocument, Global.GlobalConst.Schema.REFERRER);
        }
    }
}
