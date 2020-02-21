using ITS.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;


#region Comment

/*
  Page Name:  ReferrerProjectTreatmentEmailConfiguration.cs                      
  Version:  1.0                                              
  Purpose: Added configuration For ReferrerProjectTreatmentEmailConfiguration
  Revision History:                               
  1.0 – 11/14/2012 Harpreet Singh  
  
 */


#endregion
namespace ITS.Core.Data.SqlServer.Configuration
{
    public class ReferrerProjectTreatmentEmailConfiguration : EntityTypeConfiguration<ReferrerProjectTreatmentEmail>
    {
        public ReferrerProjectTreatmentEmailConfiguration()
            : base()
        {
            HasKey(referrerTreatmentEmail => referrerTreatmentEmail.ReferrerProjectTreatmentEmailID);
            ToTable(Global.Table.referrer.ReferrerProjectTreatmentEmails, Global.GlobalConst.Schema.REFERRER);

        }
    }
}
