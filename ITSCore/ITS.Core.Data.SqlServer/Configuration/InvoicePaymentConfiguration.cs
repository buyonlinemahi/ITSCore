using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


namespace ITS.Core.Data.SqlServer.Configuration
{
    public class InvoicePaymentConfiguration : EntityTypeConfiguration<InvoicePayment>
    {
        public InvoicePaymentConfiguration()
            : base()
        {
            HasKey(InvoicePaymentObj => InvoicePaymentObj.InvoicePaymentID);
            ToTable(Global.Table.global.InvoicePayment, Global.GlobalConst.Schema.GLOBAL);
          
         

        }

    }
}
