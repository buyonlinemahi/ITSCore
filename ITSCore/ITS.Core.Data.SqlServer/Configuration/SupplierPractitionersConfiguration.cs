using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

#region Comment
/*
 Author : Vijay Kumar
 created date : 01/02/2013
 Purpose : Addd Configuration For SupplierPractitioners
 Version : 1.0


 
 */
#endregion
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SupplierPractitionersConfiguration : EntityTypeConfiguration<SupplierPractitioners>
    {

        public SupplierPractitionersConfiguration()
            : base()
        {
            HasKey(SupplierPractitioners => SupplierPractitioners.SupplierPractitionerID);

            ToTable(Global.Table.supplier.SupplierPractitioner, Global.GlobalConst.Schema.SUPPLIER);

        }
    }
}
