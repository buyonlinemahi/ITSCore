using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ComplaintTypeConfiguration : EntityTypeConfiguration<ComplaintType>
    {
        public ComplaintTypeConfiguration()
            : base()
        {
            HasKey(complaintType => complaintType.ComplaintTypeID);
            Property(complaintType => complaintType.ComplaintTypeName);
            ToTable(Global.Table.lookup.ComplaintType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
