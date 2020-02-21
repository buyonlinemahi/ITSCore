using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  AssessmentTypeConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create AssessmentTypeConfiguration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/07/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class AssessmentTypeConfiguration : EntityTypeConfiguration<AssessmentType>
    {
        public AssessmentTypeConfiguration()
            : base()
        {
            HasKey(assessmentType => assessmentType.AssessmentTypeID);
            Property(assessmentType => assessmentType.AssessmentTypeName);
            ToTable(Global.Table.lookup.AssessmentType, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
