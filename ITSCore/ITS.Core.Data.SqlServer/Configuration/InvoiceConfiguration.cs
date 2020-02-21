using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
   public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
       public InvoiceConfiguration()
            : base()
        {
            HasKey(InvoiceObj => InvoiceObj.InvoiceID);
            ToTable(Global.Table.global.Invoice, Global.GlobalConst.Schema.GLOBAL);
          
         

        }

    }
}
