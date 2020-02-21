using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

/*
Latest Version:1.0
 * Author : Vishal
 * Date : 12/15/2012
 * Task : #279
 * Description : Add Configuration For Solicitor
 

 */
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class SolicitorConfiguration : EntityTypeConfiguration<Solicitor>
    {
        public SolicitorConfiguration()
            : base()
        {
            HasKey(Solicitor => Solicitor.SolicitorID);
            ToTable(Global.Table.global.Solicitor, Global.GlobalConst.Schema.GLOBAL);
          
         

        }
    }

   
}
