using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ITS.Core.Data.SqlServer.Configuration
{
    class EmploymentConfiguration : EntityTypeConfiguration<Employment>
    {
        public EmploymentConfiguration()
            : base()
        {
            HasKey(employ => employ.EmploymentId);
            ToTable(Global.Table.global.Employment, Global.GlobalConst.Schema.GLOBAL);
        }
    }
}
