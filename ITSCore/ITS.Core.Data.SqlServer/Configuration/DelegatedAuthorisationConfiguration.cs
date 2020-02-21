using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  DelegatedAuthorisationConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create DelegatedAuthorisation to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/07/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class DelegatedAuthorisationConfiguration : EntityTypeConfiguration<DelegatedAuthorisation>
    {
        public DelegatedAuthorisationConfiguration()
            : base()
        {
            HasKey(delegatedAuthorisation => delegatedAuthorisation.DelegatedAuthorisationID);
            Property(delegatedAuthorisation => delegatedAuthorisation.DeletegatedAuthorisationName);
            ToTable(Global.Table.lookup.DelegatedAuthorisation, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
