using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
/*
Page Name:  AssessmentServiceConfiguration.cs                      
 Version:  1.0                                              
 Purpose: create Assessment ServiceConfiguration to ingrtate with ITS                                                       
 Revision History:                                        
                                                           
   1.0 – 11/07/2012 Satya   
* 
*/
namespace ITS.Core.Data.SqlServer.Configuration
{
  public  class AssessmentServiceConfiguration: EntityTypeConfiguration<AssessmentService>
    {
      public AssessmentServiceConfiguration()
            : base()
        {
            HasKey(assessmentService => assessmentService.AssessmentServiceID);
            Property(assessmentService => assessmentService.AssessmentServiceName);
            ToTable(Global.Table.lookup.AssessmentService, Global.GlobalConst.Schema.LOOKUP);
        }
    }
}
