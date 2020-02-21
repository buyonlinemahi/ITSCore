using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;



/* ============================================================================= 
 *  Page Name:  DelegatedAuthorisationTypesConfiguration.cs                      
    Version:    1.0 
    Author:     Vijay  Kumar
 *  Date:       12-06-2012
    Purpose:    create DelegatedAuthorisationTypes Configuration 
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
    public class DelegatedAuthorisationTypesConfiguration:EntityTypeConfiguration<DelegatedAuthorisationTypes>
    {
        public DelegatedAuthorisationTypesConfiguration()
            : base()
        {
            HasKey(delegatedAuthorisationTypes => delegatedAuthorisationTypes.DelegatedAuthorisationTypeID);
            Property(delegatedAuthorisationTypes => delegatedAuthorisationTypes.DelegatedAuthorisationTypeName);
            ToTable(Global.Table.lookup.DelegatedAuthorisationType, Global.GlobalConst.Schema.LOOKUP);
        }

    }
}
