using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class EmployeeDetailConfiguration : EntityTypeConfiguration<EmployeeDetail>
    {
        public EmployeeDetailConfiguration()
            :base()
    {
        HasKey(EmpDetailObj => EmpDetailObj.EmployeeDetailID);
            ToTable(Global.Table.global.EmployeeDetail, Global.GlobalConst.Schema.GLOBAL);
    }
    }
}
