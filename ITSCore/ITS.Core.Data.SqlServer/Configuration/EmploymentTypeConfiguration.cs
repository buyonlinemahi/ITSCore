using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class EmploymentTypeConfiguration : EntityTypeConfiguration<EmploymentType>
    {
        public EmploymentTypeConfiguration()
            : base()
        {
            HasKey(employ => employ.EmploymentTypeID);
            ToTable(Global.Table.lookup.EmploymentType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
