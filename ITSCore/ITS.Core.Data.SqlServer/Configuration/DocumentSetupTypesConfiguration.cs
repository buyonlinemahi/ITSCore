using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;



/* ============================================================================= 
 *  Page Name:  DocumentSetupTypesConfiguration.cs                      
    Version:    1.0 
    Author:     Vijay  Kumar
 *  Date:       12-06-2012
    Purpose:    create DocumentSetupTypesConfiguration Configuration 
 * ======================================================================================
    Revision History:                                        
    Version:    1.0, Vijay Kumar  
 *  Date:       12-06-2012
    

   */
/// <summary>
/// 
/// </summary>
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class DocumentSetupTypesConfiguration:EntityTypeConfiguration<DocumentSetupTypes>
    {
        public DocumentSetupTypesConfiguration()
            : base()
        {
            HasKey(documentSetupTypesConfiguration => documentSetupTypesConfiguration.DocumentSetupTypeID);
            Property(documentSetupTypesConfiguration => documentSetupTypesConfiguration.DocumentSetupTypeName);
            ToTable(Global.Table.lookup.DocumentSetupType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
