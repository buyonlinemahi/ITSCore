using System.Data.Entity.ModelConfiguration;

using ITS.Core.Data.Model;

namespace ITS.Core.Data.SqlServer.Configuration
{
    public class BankHolidayConfiguration : EntityTypeConfiguration<BankHoliday> 
    {
        public BankHolidayConfiguration()
            : base()
        {
            HasKey(bankHoliday => bankHoliday.BankHolidayID);
            Property(bankHoliday => bankHoliday.BankHolidayName);
            Property(bankHoliday => bankHoliday.BankHolidayDate);
            ToTable(Global.Table.lookup.BankHoliday, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
