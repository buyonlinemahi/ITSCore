using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ComplaintStatusConfiguration : EntityTypeConfiguration<ComplaintStatus>
    {
        public ComplaintStatusConfiguration()
            : base()
        {
            HasKey(complaintStatus => complaintStatus.ComplaintStatusID);
            Property(complaintStatus => complaintStatus.ComplaintStatusName);
            ToTable(Global.Table.lookup.ComplaintStatus, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
