using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


#region Comment
/*
 Author : Robin Singh
 created date : 01/03/2013
 Purpose : Addd Configuration For Case
 Version : 1.0
 
 
 */
#endregion

namespace ITS.Core.Data.SqlServer.Configuration
{
   public class CaseConfiguration : EntityTypeConfiguration<Case>
    {
       public CaseConfiguration()
            : base()
        {
            HasKey(caseObj => caseObj.CaseID);
            ToTable(Global.Table.global.Case, Global.GlobalConst.Schema.GLOBAL);
          
         

        }

    }
}
